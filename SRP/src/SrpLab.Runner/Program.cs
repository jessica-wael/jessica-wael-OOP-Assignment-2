using SrpLab;
using SrpLab.KitchenTicket;
using SrpLab.LoanDesk;
using SrpLab.SubscriptionBilling;
using SrpLab.SupportTicket;
using SrpLab.WarehousePickList;

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
Console.WriteLine("=================================================");

//Ward Board
var beds = new BedAssignments();
var scorer = new AcuityScorer();
var pagerPolicy = new PagerAlertPolicy();
var pagerLog = new PagerLog();

var acuity = scorer.Score(heartRate: 130, spo2: 89);
beds.Assign(1, "p-88", acuity);
if (pagerPolicy.ShouldAlert(acuity)) pagerLog.Add(1);

Console.WriteLine(new HandoffNoteWriter().Write(
    1, beds.PatientAt(1), beds.AcuityAt(1), pagerPolicy.ToneFor(beds.AcuityAt(1))));
Console.WriteLine(string.Join(" | ", pagerLog.Drain()));

//Checkout Basket
var basket = new ShoppingBasket();
basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
var subTotal = basket.SubTotal();
var discount = new CouponDiscountCalculator().Calculate(basket.CouponText, subTotal);
var giftWrapFee = new GiftWrapFeePolicy().FeeFor(basket.GiftWrapRequested);
var grandTotal = new CheckoutTotalCalculator().Calculate(subTotal, discount, giftWrapFee);

Console.WriteLine($"basket total={grandTotal} auth={new PaymentAuthorizationStub().Authorize(grandTotal, "4242", basket.LineCount)}");

//Support Ticket
var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);

ticket.SetPriority(new PriorityClassifier().Classify(ticket.Subject, ticket.Body));
var supportDeadline = new SlaPolicy().Deadline(ticket.OpenedAt, ticket.Priority);
Console.WriteLine(new PublicReplyWriter().Write(ticket.Id, ticket.Priority, "Nora", supportDeadline));


//Load Desk
var application = new LoanApplication(60_000m, 640, 4, HasCollateral: false);
var risk = new RiskScorer().Score(application);
var eligible = new EligibilityPolicy().IsEligible(application, risk);
var requiredDocs = new RequiredDocumentsList().For(application, eligible);
Console.WriteLine(new DecisionLetterWriter().Write("Omar", application, risk, eligible, requiredDocs));

//Course Enrollment Desk
var students = new CourseRegister("SEF-101", capacity: 1);
Console.WriteLine(students.Register("a@mail.com"));
Console.WriteLine(students.Register("b@mail.com"));
Console.WriteLine(new WelcomePacketWriter().Write(
    students.CourseCode, "Bea",
    students.IsSeated("b@mail.com"),
    students.WaitlistPosition("b@mail.com")));
Console.WriteLine(new TuitionInvoiceLineWriter(new VatPolicy())
    .Write(students.CourseCode, 3000m, students.IsSeated("a@mail.com")));

// Kitchen Ticket
var order = new OrderTicket();
order.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
var allergens = new AllergenDetector().Detect(order.Items);
var eta = new ReadyTimeEstimator().Estimate(order.Items, allergens.Count > 0, openStations: 2);
Console.WriteLine(new ThermalTicketPrinter().Render(42, order.Items, eta, allergens));


// subscribtion Billing
var period = new BillingPeriod(new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
var failures = new PaymentFailureTracker();
failures.Register();
var amountDue = new ProrationCalculator().Prorate(99m, period, period.Start);
var invoiceNumber = new InvoiceNumberGenerator().Next(period.Start);
Console.WriteLine(new DunningEmailWriter().Write("Sara", amountDue, new DateOnly(2026, 9, 20), failures.Failures, invoiceNumber));

// wareehouse Picklist
var pick = new PickList();
pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);
var walkingOrder = new WalkingOrderPlanner().Plan(pick.Lines);
Console.WriteLine(new PickerScriptWriter().Write(walkingOrder, pick.Lines));


//Grade Book
var scoreBook = new ScoreBook();
scoreBook.Record("s1", 92);
scoreBook.Record("s1", 88);

var average = new AverageCalculator().Calculate(scoreBook.ScoresOf("s1"));
var letter = new LetterGradePolicy().ToLetter(average);
var honor = new HonorRollPolicy().Qualifies(average, letter);
Console.WriteLine(new TranscriptWriter().Write("s1", "Ali", average, letter, honor));


//Appointment Desk
var hours = new BusinessHours(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
var book = new AppointmentBook(hours);
var finder = new SlotFinder(hours, book);
var slot = finder.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
if (slot is null) throw new InvalidOperationException("no slot");
book.TryBook(slot.Value);
Console.WriteLine(new SmsReminderWriter().Write(slot.Value, "0100"));

Console.WriteLine("\nDone. Now split responsibilities — without breaking behavior.\n");
