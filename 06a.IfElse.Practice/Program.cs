// Top level program

using _06a.IfElse.Practice;
using BenchmarkDotNet.Reports;
using Gee.External.Capstone.M68K;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;

#region Only If Statement - Practice 1
/*
 * 1) Use the if statement to print "Hello World" with the condition that it is always true
 */


if (true) Console.Write("HELLO WORLD!");
Console.WriteLine("\n--------");

#endregion


#region If-Else Statement and Ternary Conditional Operator  - Practice 2
/*
 * 2) Check if 3 points (2, 0), (3, 1), (1, -1) are collinear by using if/else statement and ternary conditional operator.
 * 
 * A(x1, y1), B(x2, y2), C(x3, y3)
 * 
 * Vector AB = (x2 - x1, y2 - y1)
 * Vector BC = (x3 - x2, y3 - y2)
 * 
 * x2 - x1   y2 - y1
 * ------- = -------  
 * x3 - x2   y3 - y2
 * 
 * => (x2 - x1) * (y3 - y2) = (y2 - y1) * (x3 - x2 )
 * => (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2 ) = 0
 * 
 */
(int x1, int y1) a = (2, 0);  //A(x1,y1) 
(int x2, int y2) b = (3, 1);  //B(x2,y2) 
(int x3, int y3) c = (1, -1); //C(x3,y3) 

int result = (b.x2 - a.x1) * (c.y3 - b.y2) - (b.y2 - a.y1) * (c.x3 - b.x2);
//Use if/else statement
if (result == 0)
    Console.WriteLine($"{a}, {b}, {c} are collinear");
else
    Console.WriteLine($"{a}, {b}, {c} are not collinear");

//Use ternary conditional operator
Console.WriteLine($"{a}, {b}, {c} are {(result == 0 ? string.Empty : "not")}colliner");
Console.WriteLine("\n--------");

#endregion


#region Nested If-Else Statement and Nested Ternary Conditional Operator  - Practice 3
/*
 * 3) A student has the following scores: 10 points in math, 8 points in physics, 6 points in chemistry, 4 points in literature, and 7 points in English.
 * Calculate the average score and grade the academic performance according to the following criteria: 
 * - score >= 9: Excellent
 * - score >= 8: Very Good
 * - score >=6.5: Good
 * - score >= 5: Average
 * - score >=4: Pass
 * - score < 4: Failed
 */

float
    math = 10f,
    physics = 8f,
    chemistry = 6f,
    literature = 4f,
    english = 7f;

float averageScore = (math + physics + chemistry + literature + english) / 5;
Console.WriteLine($"Average score: {averageScore}");
//Use nested if/else statement
if (averageScore >= 9f)
{
    Console.WriteLine($"Grade: Excellent");
}
else if (averageScore >= 8f)
{
    Console.WriteLine($"Grade: Very good");
}
else if (averageScore >= 6.5f)
{
    Console.WriteLine($"Grade: Good");
}
else if (averageScore >= 5f)
{
    Console.WriteLine($"Grade: Pass");
}
else if (averageScore >= 4f)
{
    Console.WriteLine($"Grade: Average");
}
else
{
    Console.WriteLine($"Grade: Failed");
}
Console.WriteLine("--------");
#endregion


#region Pattern Matching - Type Pattern - Delacration Pattern
/*
 * void Function(object value)
 * - if value is null   =>                         => print warning
 * - if value is string => if value start with "M" => print value
 * - if value is int    => if value >= 18          => print value
 * - if value is bool   => if value is true        => print value
 */

object
    nullObject = null,
    nameObject = "Manh",
    ageObject = 18,
    genderObject = true;

#region Type Pattern History Version 1
void TypePatternHistoryV1(object value)
{
    if (value == null)
    {
        Console.WriteLine("value is null");
    }
    else if (value.GetType() == typeof(string))
    {
        string name = (string)value;

        if (name.StartsWith("M"))
            Console.WriteLine($"Name: {name}");
    }
    else if (value.GetType() == typeof(int))
    {
        int age = (int)value;

        if (age >= 18)
            Console.WriteLine($"Age: {age}");
    }
    else if (value.GetType() == typeof(bool))
    {
        bool gender = (bool)value;
        if (gender is true)
            Console.WriteLine($"Gender is Male");
    }
}
Console.WriteLine("\n----Type Pattern History Version 1----");
TypePatternHistoryV1(nullObject);
TypePatternHistoryV1(nameObject);
TypePatternHistoryV1(ageObject);
TypePatternHistoryV1(genderObject);
#endregion


#region Type Pattern History Version 2
void TypePatternHistoryV2(object value)
{
    string? name = value as string;
    int? age = value as int?;
    bool? gender = value as bool?;

    if (value == null)
    {
        Console.WriteLine("Value is null");
    }
    else if (name != null && name.StartsWith("M"))
    {
        Console.WriteLine($"Name = {name}");
    }
    else if (age != null && age >= 18)
    {
        Console.WriteLine($"Age = {age}");
    }
    else if (gender != null && (bool)gender)
    {
        Console.WriteLine($"Gender = Male");
    }
}
Console.WriteLine("\n----Type Pattern History Version 2----");
TypePatternHistoryV2(nullObject);
TypePatternHistoryV2(nameObject);
TypePatternHistoryV2(ageObject);
TypePatternHistoryV2(genderObject);
#endregion


#region Type Pattern With "is" Pattern Expression

void TypePatternWithIsPatternExpression(object value)
{
    if (value is null)
        Console.WriteLine("Value is null");

    else if (value is string)
    {
        string name = value as string;
        if (name.StartsWith("M"))
            Console.WriteLine($"Name: {name}");
    }
    else if (value is int)
    {
        int? age = value as int?;
        if (age >= 18)
            Console.WriteLine($"Age: {age}");

    }
    else if (value is bool)
    {
        bool? gender = value as bool?;
        if ((bool)gender)
            Console.WriteLine($"Gender: Male");
    }
}
Console.WriteLine("\n----Type Pattern With 'is' Pattern Expression----");
TypePatternWithIsPatternExpression(nullObject);
TypePatternWithIsPatternExpression(nameObject);
TypePatternWithIsPatternExpression(ageObject);
TypePatternWithIsPatternExpression(genderObject);
#endregion


#region Type Pattern With "is" Pattern Expression and Delacration Pattern
void TypePatternWithIsPatternExpressionAndDeclarationPattern(object value)
{
    if (value is null)
        Console.WriteLine("Value is null");
    else if (value is string name && name.StartsWith("M"))
        Console.WriteLine($"Name = {name}");
    else if (value is int age && age >= 18)
        Console.WriteLine($"Age is {age}");
    else if (value is bool gender)
        Console.WriteLine($"Gender = Female");
}
Console.WriteLine("\n----Type Pattern With 'is' Pattern Expression And Declaration Pattern----");

TypePatternWithIsPatternExpressionAndDeclarationPattern(nullObject);
TypePatternWithIsPatternExpressionAndDeclarationPattern(nameObject);
TypePatternWithIsPatternExpressionAndDeclarationPattern(ageObject);
TypePatternWithIsPatternExpressionAndDeclarationPattern(genderObject);
#endregion
#endregion


#region Pattern Matching - Logical Pattern - Parenthesized pattern  - Practice 4
/*
 * 4) In a class of 45 students, each student will be assigned a number between 1 and 45 that does not overlap. 
 * The teacher needed to divide into groups for activities, so he divided the number of each student by 9, the remainder of the division was the criterion to arrange the students in groups as follows:
 * - Group 1: (0, 3, 6)
 * - Group 2: (1, 4, 7)
 * - Group 3: (2, 5, 8)
 * 
 * Given the number of a student, check which group the student belongs to? (Use If-Else statement to solve this problems)
 */
void GroupByV1(int number)
{
    int remainder = number % 9;
    int group = remainder % 3 + 1;

    Console.WriteLine($"Student with number {number,2} is arrange into group {group}");
}
Console.WriteLine("\n----Logical Pattern and Declaration Pattern version 1----");
for (int i = 1; i <= 12; i++)
    GroupByV1(i);

void GroupByV2(int number)
{
    int remainder = number % 9;
    string template = "Student with number {0} is arrange into group {1}";

    if (remainder == 0 || remainder == 6 || remainder == 3)
    {
        Console.WriteLine(template, number, 1);
    }
    if (remainder == 1 || remainder == 4 || remainder == 7)
    {
        Console.WriteLine(template, number, 2);
    }
    else
    {
        Console.WriteLine(template,number, 3);
    }
}

Console.WriteLine("\n----Logical Pattern and Declaration Pattern version 2----");
for (int i = 1; i <= 12; i++)
    GroupByV2(i);

void GroupByV3(int number)
{
    int remainder = number % 9;
    string template = "Student with number {0} is arrange into group {1}";

    if (remainder is 0 or 3 or 6)
    {
        Console.WriteLine(template, number, 1);
    }
    if (remainder is 1 or 4 or 7)
    {
        Console.WriteLine(template, number, 2);
    }
    else
    {
        Console.WriteLine(template, number, 3);
    }
}

Console.WriteLine("\n----Logical Pattern and Declaration Pattern version 3----");
for (int i = 1; i <= 12; i++)
    GroupByV3(i);

void GroupByV4(int number)
{
    int remainder = number % 9;
    string template = "Student with number {0} into group {1}";
    if (remainder is not (1 or 4 or 7 or 2 or 5 or 8))
    {
        Console.WriteLine(template, number, 1);
    }
    else if (remainder is not (2 or 5 or 8))
    {
        Console.WriteLine(template, number, 2);
    }
    else
        Console.WriteLine(template, number, 3);
}
Console.WriteLine("\n----Logical Pattern and Declaration Pattern version 4----");
for (int i = 0; i <= 12; i++)
{
    GroupByV4(i);
}

void GroupByV5(int number)
{
    int remainder = number % 9;
    string template = "Student with number {0} into group {1}";

    if (remainder is not 1 and not 4 and not 7 and not 2 and not 5 and not 8)
    {
        Console.WriteLine(template, number, 1);
    }
    else if (remainder is not 2 and not 5 and not 8)
    {
        Console.WriteLine(template, number, 2);
    }
    else
        Console.WriteLine(template, number, 3);
}
Console.WriteLine("\n----Logical Pattern and Declaration Pattern version 5----");
for (int i = 1; i <= 12; i++)
    GroupByV5(i);
#endregion


#region Pattern Matching - Relational Pattern (<, > , <=, >=) - Practice 5
/*
 * 5) Men New European System Clothing Standard Body Measurements
 *             |   XS    ||    S    ||     M     ||     L     ||     XL    |
 * bust girth  | 78 - 82 || 86 - 90 ||  94 - 98  || 102 - 107 || 107 - 113 |    
 * waist girth | 62 - 66 || 70 - 74 ||  78 - 82  ||  86 - 91  ||  91 - 97  |
 * hip girth   | 86 - 90 || 94 - 98 || 102 - 106 || 110 - 115 || 115 - 120 |
 *
 * With a man's bust girth, waist girth and- hip girth figures, help him choose the right shirt size. (Use  Relational Pattern to solve this problems)
 */
Console.WriteLine("----------------------------\n\n");

void ChooseRightShirtSize(int bustGirth, int waistGirth, int hipGirth)
{
    string template = $"Shirt size for {bustGirth}, {waistGirth}, {hipGirth} is {{0}}";

    if (bustGirth >= 78 && bustGirth <= 82 && waistGirth >= 62 && waistGirth <= 66 && hipGirth >= 86 && hipGirth <= 90) 
    {
        Console.WriteLine(template, "XS");
    }
    else if(bustGirth >= 86 && bustGirth <= 90 && waistGirth >= 70 && waistGirth <= 74 && hipGirth >= 94 && hipGirth <= 98)
    {
        Console.WriteLine(template, "S");
    }
    else if(bustGirth >= 94 && bustGirth <= 98 && waistGirth >= 78 && waistGirth <= 82 && hipGirth >= 102 && hipGirth <= 106)
    {
        Console.WriteLine(template, "M");
    }
    else if(bustGirth >= 102 && bustGirth <= 107 && waistGirth >= 86 && waistGirth <= 91 && hipGirth >= 110 && hipGirth <= 115)
    {
        Console.WriteLine(template, "L");
    }
    else if(bustGirth >= 107 && bustGirth <= 113 && waistGirth >= 91 && waistGirth <= 97 && hipGirth >= 115 && hipGirth <= 120)
    {
        Console.WriteLine(template, "XL");
    }
    else
    {
        Console.WriteLine(template, "not found");
    }
}
Console.WriteLine("----Relational Pattern version 1----");
ChooseRightShirtSize(78, 70, 90);
ChooseRightShirtSize(79, 65, 89);
ChooseRightShirtSize(87, 73, 95);
ChooseRightShirtSize(95, 82, 106);
ChooseRightShirtSize(103, 86, 110);
ChooseRightShirtSize(108, 91, 115);


void ChooseRightShirtSizeV2(int bustGirth, int waistGirth, int hipGirth)
{
    string template = $"Shirt size for {bustGirth}, {waistGirth}, {hipGirth} is {{0}}";

    if (bustGirth is >= 78 and <= 82 && waistGirth is >= 62 and <= 66 && hipGirth is >= 86 and <= 90)
    {
        Console.WriteLine(template, "XS");
    }
    else if (bustGirth is >= 86 and <= 90 && waistGirth is >= 70 and <= 74 && hipGirth is >= 94 and <= 98)
    {
        Console.WriteLine(template, "S");
    }
    else if (bustGirth is >= 94 and <= 98 && waistGirth is >= 78 and <= 82 && hipGirth is >= 102 and <= 106)
    {
        Console.WriteLine(template, "M");
    }
    else if (bustGirth is >= 102 and <= 107 && waistGirth is >= 86 and <= 91 && hipGirth is >= 110 and <= 115)
    {
        Console.WriteLine(template, "L");
    }
    else if (bustGirth is >= 107 and <= 113 && waistGirth is >= 91 and <= 97 && hipGirth is >= 115 and <= 120)
    {
        Console.WriteLine(template, "XL");
    }
    else
    {
        Console.WriteLine(template, "not found");
    }
}
Console.WriteLine("\n----Relational Pattern version 2----");
ChooseRightShirtSizeV2(78, 70, 90);
ChooseRightShirtSizeV2(79, 65, 89);
ChooseRightShirtSizeV2(87, 73, 95);
ChooseRightShirtSizeV2(95, 82, 106);
ChooseRightShirtSizeV2(103, 86, 110);
ChooseRightShirtSizeV2(108, 91, 115);

void ChooseRightShirtSizeV3(int bustGirth, int waistGirth, int hipGirth)
{
    string template = $"Shirt size for {bustGirth}, {waistGirth}, {hipGirth} is {{0}}";

    if (bustGirth is not (< 78 or > 82) && waistGirth is not (< 62 or > 66) && hipGirth is not (< 86 or > 90))
    {
        Console.WriteLine(template, "XS");
    }
    else if (bustGirth is not (< 86 or > 90) && waistGirth is not (< 70 or > 74) && hipGirth is not (< 94 or > 98))
    {
        Console.WriteLine(template, "S");
    }
    else if (bustGirth is not (< 94 or > 98) && waistGirth is not (< 78 or > 82) && hipGirth is not (< 102 or > 106))
    {
        Console.WriteLine(template, "M");
    }
    else if (bustGirth is not (< 102 or > 107) && waistGirth is not (< 86 or > 91) && hipGirth is not (< 110 or > 115))
    {
        Console.WriteLine(template, "L");
    }
    else if (bustGirth is not (< 107 or > 113) && waistGirth is not (< 91 or > 97) && hipGirth is not (< 115 or > 120))
    {
        Console.WriteLine(template, "XL");
    }
    else
    {
        Console.WriteLine(template, "not found");
    }
}
Console.WriteLine("\n----Relational Pattern version 3----");
ChooseRightShirtSizeV3(78, 70, 90);
ChooseRightShirtSizeV3(79, 65, 89);
ChooseRightShirtSizeV3(87, 73, 95);
ChooseRightShirtSizeV3(95, 82, 106);
ChooseRightShirtSizeV3(103, 86, 110);
ChooseRightShirtSizeV3(108, 91, 115);
#endregion


#region Pattern Matching - Property Pattern - Practice 6
/*
 * 7) Give information on the fare lists of the two buffet restaurants, 
 *    helping customers find the right fare for the respective restaurant based on the restaurant's conditions.
 * 
 * Hoang Yen Buffet
 * ================
 * 
 * Day of Weeks     | Session | Price
 * -----------------------------------------------------------------
 * Monday to Friday | Noon    | 255.000 VND
 * Saturday, Sunday | Noon    | 375.000 VND
 * Monday to Sunday | Night   | 375.000 VND
 * 
 * 
 * D'Maris Buffet
 * ==============
 * 
 * Day of Weeks     | Session | Price       | Child'Age (7 - 12) | Child'Age (4 - 6)
 * ----------------------------------------------------------------------------------
 * Monday to Friday | Noon    | 395.000 VND |                    | 
 * Monday to Friday | Evening | 527.000 VND | 275.000 VND        | 143.000 VND   
 * Sartuday, Sunday | Noon    | 527.000 VND |                    |
 * Sartuday, Sunday | Evening | 561.000 VND |                    |
 * 
 * 
 * 
 * Hint:
 * =====
 * DayOfWeek:
 * - 1: Sunday
 * - 2: Monday
 * - 3: Tuesday
 * - 4: Wednesday
 * - 5: Thursday
 * - 6: Friday
 * - 7: Saturday
 * 
 * Session:
 * - 1: Noon
 * - 2: Evening
 */

#region Version 1
void FindRightFareV1(object buffet)
{
    string template = "Your price: {0} VND";

    if (buffet is HoangYenBuffet { DayOfWeek: >= 2 and <= 6, Session: 1})
    {
        Console.WriteLine(template, 255_000);
    }
    else if (buffet is HoangYenBuffet)
    {
        Console.WriteLine(template, 375_000);
    }
    else if (buffet is DMarisBuffet { Age: >= 4 and <= 6 })
        Console.WriteLine(template, 143_000);

    else if (buffet is DMarisBuffet { Age: >= 7 and <= 12 })
        Console.WriteLine(template, 275_000);

    else if (buffet is DMarisBuffet { DayOfWeek: >= 2 and <= 6, Session: 1 })
        Console.WriteLine(template, 395_000);

    else if (buffet is DMarisBuffet { DayOfWeek: 7 or 8, Session: 2 })
        Console.WriteLine(template, 561_000);

    else if (buffet is DMarisBuffet)
        Console.WriteLine(template, 527_000);
    else
    {
        Console.WriteLine(template, "not found");
    }
}

Console.WriteLine("\n----Property Pattern version 1 (Practice 07)----");
FindRightFareV1(new HoangYenBuffet { DayOfWeek = 2, Session = 1 }); //Monday    Noon    => 255.000 VND
FindRightFareV1(new HoangYenBuffet { DayOfWeek = 7, Session = 1 }); //Saturday  Noon    => 375.000 VND
FindRightFareV1(new HoangYenBuffet { DayOfWeek = 8, Session = 2 }); //Sunday    Evening => 375.000 VND
FindRightFareV1(new HoangYenBuffet { DayOfWeek = 2, Session = 2 }); //Sunday    Evening => 375.000 VND
Console.WriteLine($"\n----DMaris----");
FindRightFareV1(new DMarisBuffet { Age = 5 });                      //Age 5             => 143.000 VND
FindRightFareV1(new DMarisBuffet { Age = 8 });                      //Age 8             => 275.000 VND
FindRightFareV1(new DMarisBuffet { DayOfWeek = 2, Session = 1 });   //Monday    Noon    => 395.000 VND
FindRightFareV1(new DMarisBuffet { DayOfWeek = 2, Session = 2 });   //Monday    Evening => 527.000 VND
FindRightFareV1(new DMarisBuffet { DayOfWeek = 7, Session = 1 });   //Saturday  Noon    => 527.000 VND
FindRightFareV1(new DMarisBuffet { DayOfWeek = 7, Session = 2 });   //Saturday  Evening => 561.000 VND
#endregion
#endregion


#region Pattern Matching - Nested Property Pattern - Practice 8
/*  
 *  8) Based on the description of a bookstore's shipping policy below, 
 *  write an algorithm to calculate the shipping cost a customer has to pay for their order
 *  by using Nested Property Pattern and User-Defined DataTypes "Order" and "ShippingAddress".
 *  
 *  For Retail Customer
 *  ===================
 *  
 *  | District                                           | Total Price <= $13.07 | Total > $13.07
 *  ---------------------------------------------------------------------------------------------
 *  | 1, 3, 5, 9, 10, 11, Thu Duc, Binh Thanh, Phu Nhuan | $0.87                  | Free ship
 *  | 2, 4, 6, 7, 8, 12, Tan Binh, Tan Phu               | $1.09                  | Free ship
 *  | Binh Tan, Binh Chanh, Hoc Mon, Nha Be, Binh Duong  | $1.31                  | Free ship
 *  | Not in Ho Chi Minh City                            | $2                     | $3
 *  
 *  
 *  For Wholesale Customer
 *  ======================
 *  
 *  | District                                           | Quantity <= 20         | Quantity > 20
 *  ---------------------------------------------------------------------------------------------
 *  | 1, 3, 5, 6, 10, 11, Tan Binh, Phu Nhuan            | $1                     | Free ship
 *  | 2, 4, 7, 8, 9, 12, Tan Phu, Binh Thanh, Binh Tan   | $2                     | Free ship
 *  | Thu Duc, Binh Chanh, Hoc Mon, Nha Be, Binh Duong   | $3                     | Free ship
 *  | Not in Ho Chi Minh City                            | $4                     | $5  
 *  
 * class Order
 * {
 *     public int Id { get; set; }
 *     public DateTime OrderDate { get; set; }
 *     public string? CustomerName { get; set; }
 *     public bool IsWholesaleCustomer { get; set; }
 *     public int Quantity { get; set; }
 *     public decimal Total { get; set; }
 *     public ShippingAddress? ShippingAddress { get; set; }
 * }
 * 
 * class ShippingAddress
 * {
 *     public string? Street { get; set; }
 *     public string? District { get; set; }
 *     public string? City { get; set; }
 * }
 *  
 *  
 *  Note:
 *  =====
 *  Total order cost = order cost + shipping fee (if applicable)
 *  
 */


decimal CalculateShippingCost(SalesOrder salesOrder)
{
    if (salesOrder is null) throw new Exception(nameof(salesOrder));
    decimal shippingCost =
        salesOrder is { IsWholesaleCustomer: false, Total: <= 13_07m, ShippingAddress: { District: "1" or "3" or "5" or "9" or "10" or "11" or "Thu Duc" or "Binh Thanh" or "Phu Nhuan" } } ? 0.87m :
        salesOrder is { IsWholesaleCustomer: false, Total: <= 13_07m, ShippingAddress: { District: "2" or "4" or "6" or "7" or "8" or "12" or "Tan Binh" or "Tan Phu" } } ? 1_09m :
        salesOrder is { IsWholesaleCustomer: false, Total: <= 13_07m, ShippingAddress: { District: "Binh Tan" or "Binh Chanh" or "Hooc Mon" or "Nha Be" or "Binh Duong" } } ? 1_31m :
        salesOrder is { IsWholesaleCustomer: false, Total: <= 13_07m, ShippingAddress: { City: not "Ho Chi Minh" } } ? 2m :
        salesOrder is { IsWholesaleCustomer: false, Total: > 13_07m, ShippingAddress: { City: not "Ho Chi Minh" } } ? 3m :
        salesOrder is { IsWholesaleCustomer: true, Quantity: <= 20, ShippingAddress: { District: "1" or "3" or "5" or "6" or "10" or "11" or "Tan Binh" or "Phu Nhuan" } } ? 1m :
        salesOrder is { IsWholesaleCustomer: true, Quantity: <= 20, ShippingAddress: { District: "2" or "4" or "7" or "8" or "9" or "12" or "Tan Phu" or "Binh Thanh" or "Binh Tan" } } ? 2m :
        salesOrder is { IsWholesaleCustomer: true, Quantity: <= 20, ShippingAddress: { District: "Thu Duc" or "Binh Chanh" or "Hooc Mon" or "Nha Be" or "Binh Duong" } } ? 3m :
        salesOrder is { IsWholesaleCustomer: true, Quantity: <= 20, ShippingAddress: { City: not "Ho Chi Minh" } } ? 4m :
        salesOrder is { IsWholesaleCustomer: true, Quantity: > 20, ShippingAddress: { City: not "Ho Chi Minh" } } ? 5m : 0m;
    return shippingCost;
}
#region Order
Console.WriteLine("\n----Nested Property Pattern----");
SalesOrder salesOrder = new SalesOrder()
{
    Id = 1,
    Customer = "Quynh Nhung",
    dateTime = DateTime.Now,
    IsWholesaleCustomer = false,
    Total = 5m,
    ShippingAddress = new ShippingAddress
    {
        Street = "Bach Dang",
        District = "Binh Thanh",
        City = "Ho Chi Minh"
    }
};
SalesOrder salesOrder2 = new SalesOrder()
{
    Id = 2,
    Customer = "Do Thi Quynh Nhu",
    dateTime = new DateTime(2023, 5, 2),
    IsWholesaleCustomer = true,
    Quantity = 21,
    Total = 14m,
    ShippingAddress = new ShippingAddress
    {
        Street = "Pham Van Dong",
        District = "Thu Duc",
        City = "Ho Chi Minh"
    }
};
SalesOrder salesOrder3 = new SalesOrder()
{
    Id = 3,
    Customer = "Nguyen Van Dau",
    dateTime = DateTime.Now,
    IsWholesaleCustomer = true,
    Quantity = 19,
    Total = 1m,
    ShippingAddress = new ShippingAddress
    {
        Street = "Pham Van Dong",
        District = "Cau Giay",
        City = "Ha Noi"
    }
};
#endregion

Console.WriteLine($"Sales Order 1: {salesOrder.dateTime + " - Name: " + salesOrder.Customer + " - Price: " + "$" +CalculateShippingCost(salesOrder)}");
Console.WriteLine($"Sales Order 2: {salesOrder2.dateTime + " - Name: " + salesOrder2.Customer + " - Price: " + "$" + CalculateShippingCost(salesOrder2)}");
Console.WriteLine($"Sales Order 3: {salesOrder3.dateTime + " - Name: " + salesOrder3.Customer + " - Price: " + "$" + CalculateShippingCost(salesOrder3)}");
#endregion


#region Pattern Matching - Positional Pattern - Practice 10
/*
 * 10) The code given below is used to check if the date information is valid or not, written in C. 
 * Let's rewrite the code in C# using Positional pattern, combined with other Pattern Matching.
 * (Just rewrite the algorithm to check whether the date is valid or not.) 
 *
 * ----------------------------------------------------------------------------------------------------------------
 * #include <stdio.h>
 *  
 * int main()
 * {
 *     int dd,mm,yy;
 *      
 *     printf("Enter date (DD/MM/YYYY format): ");
 *     scanf("%d/%d/%d",&dd,&mm,&yy);
 *      
 *     //check year
 *     if(yy>=1900 && yy<=9999)
 *     {
 *         //check month
 *         if(mm>=1 && mm<=12)
 *         {
 *             //check days
 *             if((dd>=1 && dd<=31) && (mm==1 || mm==3 || mm==5 || mm==7 || mm==8 || mm==10 || mm==12))
 *                 printf("Date is valid.\n");
 *             else if((dd>=1 && dd<=30) && (mm==4 || mm==6 || mm==9 || mm==11))
 *                 printf("Date is valid.\n");
 *             else if((dd>=1 && dd<=28) && (mm==2))
 *                 printf("Date is valid.\n");
 *             else if(dd==29 && mm==2 && (yy%400==0 ||(yy%4==0 && yy%100!=0)))
 *                 printf("Date is valid.\n");
 *             else
 *                 printf("Day is invalid.\n");
 *         }
 *         else
 *         {
 *             printf("Month is not valid.\n");
 *         }
 *     }
 *     else
 *     {
 *         printf("Year is not valid.\n");
 *     }
 *  
 *     return 0;    
 * }
 * ----------------------------------------------------------------------------------------------------------------
 * Reference: https://www.includehelp.com/c-programs/validate-date.aspx
 */

void ValidateDate(int year,int month,int day)
{
    var date = (year, month, day, isLapYear: year % 4 == 0 && year % 100 != 0);

    bool isValid = date is ( >= 1990 and <= 9999, _, _, _)
        and (_, 1 or 3 or 5 or 7 or 8 or 10 or 12, >= 1 and <= 31, _)
        or (_, 4 or 6 or 9 or 11, >= 1 and <= 30, _)
        or (_, 2, >= 1 and <= 28, _)
        or (_, 2, 29, true);
    Console.WriteLine($"{year}-{month}-{day} is {(isValid ? "valid" : "unvalid")}");
}
Console.WriteLine("\n----Positional Pattern----");
ValidateDate(2000, 5, 27);
ValidateDate(2024, 12, 31);
ValidateDate(2024, 2, 29);
ValidateDate(2023, 2, 29);
#endregion

#region Class ShippingCost For Practice 8
class SalesOrder
{
    public int Id { get; set; }
    public string? Customer { get; set; }
    public DateTime dateTime { get; set; }
    public bool IsWholesaleCustomer { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public ShippingAddress? ShippingAddress { get; set; }
}

class ShippingAddress
{
    public string? Street { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
}

#endregion
