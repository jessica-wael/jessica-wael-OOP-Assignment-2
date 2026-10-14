## Class AppointmentDesk
the responsibilities :
  1- check the work hours 
  2- find the next free appointment slot 
  3- book the appointment
  4- Create the ICS calendar file for the appointment
  5- Send the reminder sms to the user

 why it's a problem:
    eache thing changes for different reasons. if the clinic changes it's work hours,
   i shouldn't need to change the code that creats the ICS file or the SMS text.

## Class CheckoutBasket
the responsibilities :
  1- store the basket items and calculate the subtotal
  2- read the coupon code and calculate the discount
  3- add the gift wrap fee to the price
  4- calculate the grand total 
  5- write the gift massage card 
  6- create the payment code

 why it's a problem:
   each of these responsibilities can change for different reasons. for example if i need to edit the coupon text or change discount rate ,
   that has nothing to do with the subtotal calculation , the gift wrap fee , gift massege or the payment code.
   changing one of them should not require changing the others.


## Class CourseEnrollmentDesk
the responsibilities:
 1- register students and give them seats by capacity 
 2- manage the waitlist and promote students when seats are available 
 3- write the welcome massage
 4- create the tuition invoice line 

 why it's a problem:
    if marketing changes the welcome massage or finance changes the VAT rate or the invoice format,
     i have to open the same class that has the saets and waiting list


## Class GradeBook
the responsibilities:
  1- Store the scores and check they are between 0 and 100
  2- Calculate the average
  3- Convert the average to a letter grade
  4- Decide the honor roll
  5- Write the transcript
  6- Export the CSV

Why it's a problem:
  If the faculty changes the letter bands, I would have to open the same class that exports the CSV.
  Also, the average is calculated again inside the letter, the honor roll, the transcript and the CSV and the honor roll depends on the letter.
  So a change in how the average is calculated all of them change together

## Class KitchenTicket
the responsibilities:
  1- Store the items of the ticket
  2- find the allergens from the ingredients
  3- guess the ready time
  4- Print the thermal ticket
  5- Choose the expo lane

Why it's a problem: 
 If the allergen list changes,I would have to open the same class that prints the ticket.
 Also, the ready time adds 3 minutes when there are allergens,
so the time so the time needs the allergen check. 
And the number of stations (2) is written inside both the printing and the lane choice,
so it can easily be changed one place and forget the other.


## Class LoanDesk
the responsibilities:

1- Store the loan request data
2- Calculate the risk score
3- Decide if the person can get the laon
4- List the required documents
5- Write the decision letter
6- Export the underwriter CSV row

Why it's a problem: 
  If the risk team changes the risk formula,
 I have to open the same class that writes the letter and the CSV.
Also, the documents list needs the decision, and the letter needs the risk,the decision and the documents. 
So if I change the risk formula, the documents and the letter can change without me seeing it.

## Class SubscriptionBilling
the responsibilities:
1- Store the subscription data and the number of failed payments 
2- Calculate the prorated amount
3- Create the invoice number
4- Write the dunning email
5- Write the ledger journal line

Why it's a problem:
 If finance changes the proration rule, 
 I have to open the same class that writes the email text.
 Also, the invoice counter is static, and both the dunning email and the ledger line take a new invoice number as a hidden side effect.
 So just writing an email changes the next invoice numbers.


## Class SupportTicket
 the responsibilities:
   1- Store the ticket and its messages
   2- choose the priority from the keywords in the text
   3- Calculate the SLA deadline and check if we are late 
   4- Write the public reply to the customer
   5- Write the internal note for escalation

Why it's a problem: 
 If support changes the keywords for priority, 
I have to open the same class that writes the customer reply. 
Also, the priority is calculated again in the constructor and every time a message is added, and the SLA deadline, 
the reply and the escalation note all use it. So a small change in the keywords can change the deadlines inside the messages.

## Class WardBoard
the responsibilities:
   1- Store the beds and the patients in them
   2- Calculate the patient's acuity score
   3- Decide when to send a pager alert
   4- Keep and empty the pager log
   5- Write the nurse handoff note
   6- Export the census as CSV

Why it's a problem: 
 If the hospital changes the pager rule, I have to open the same class that writes the handoff note and the CSV.
Also, AssignBed looks like it only registers a patient, 
but it also calculates the score and writes to the pager log.
The number 8 is used both for paging and for the "ESCALATE" tone, 
so changing one place can leave the other one behind.


## Class WarehousePickList
the responsibilities:
    1- Store the items that are needed
    2- Allocate the stock
    3- Decide the walking order
    4- Write the picker instructions
    5- Create the WMS XML batch

Why it's a problem: 
 If the warehouse layout changes,
I have to open the same class that writes the instructions and the XML.
Also, the allocation rule (the smaller of needed and on hand) is written in both Allocate and WalkingOrder, 
and PickerScript calculates the shortages again by itself. So a change in the allocation rule must be repeated in several places.
    
