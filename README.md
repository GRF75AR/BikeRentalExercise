# DESIGN
I've applied TDD as the development process. 
Simplicity was always on my mind, as it's a core value of extreme programming.

The first tests focused on how to create the classes to meet the demands of the first 3 assignments, very similar.
The needed entities consisted of Bike, Customer and Rental classes. An enum of RentalPeriods enumerate the pre-set possible values representing different charges for different periods.
The exercise didn't diferentiate between qualities/prices of bikes. It could be an interesting question for the client.
RentalPrices has the sole responsibility to provide the actual prices for each RentalPeriod. It provides a simple (& single) point to get prices (very useful for tests, for example).
Rental also has a TimePeriods property to let the customer ask for 2 or more hours, for example.
The Customer had a collection of Rentals, each Rental had a Bike and a CalculatePay method on Customer added the final ammount to pay.
This was the first design, before point 4.

Point 4 of the requirements make me revise the entities to support the case. Please follow the tests on the file UnitTests.cs on the project BikeRentalTests.
There's a need to make a bulk rental operation, irrespective of time period, and with a discount to the final price.
To support these operations, an Order class was created, to handle the management of packages of rentals. 
These packages must implement a common interface (IRentalPackage) in order to support these operations and to allow extensibility.
Two implementations were created (StandardRental y FamilyRental), plus an abstract class with common code.
A factory was added to abstract the creation of each of these IRentalPackages.
Order class provides 2 different AddRentals methods: one lets the caller pass the selected bikes, the second just asks for how many bikes to rent (just in the case the system can provide any bike from the available ones).
Although the Customer only has one Order (not considering history right now), the Order allows to AddRentals as much as needed. See the test TestRentPromoAndStandard, where a customer can buy the Promo for 4 bikes 1 hour period plus 2 standard (no Promo) bikes for a full day, everything in a single order.
The last test checks to insert only 1 people in a Promo, an invalid operation.

# TESTING
From VS, you can run the tests clicking on Test on the Main Menu Bar, then Run, All Tests.