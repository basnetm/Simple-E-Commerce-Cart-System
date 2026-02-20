# Simple E-Commerce Cart System


This is a simple C# console-based e-commerce program that demonstrates **Object-Oriented Programming (OOP)** concepts like:

- **Encapsulation** (using private fields + public properties)
- **Inheritance** (`Clothing` and `Grocery` inherit from `Product`)
- **Polymorphism** (calling overridden methods through a `Product` reference)
- **Method Overriding** (`GetTaxRate()` and `Display()` are overridden)

The program lets the user create either a **Clothing** product or a **Grocery** product, enter quantity, and then calculates the **total price including tax**.

## Features

✅ Create Clothing product  
✅ Create Grocery product  
✅ Calculate tax based on product type  
✅ Calculate total price based on quantity  
✅ Display product details  
✅ Menu-driven console interface  
✅ Uses polymorphism (`Product p = c;` / `Product p = g;`)

---

## Project Structure

- `Product.cs`  
  Base class that contains common product fields and methods:
  - `Id`, `Name`, `BasePrice`
  - `GetTaxRate()` (virtual)
  - `CalculateFinalPrice(quantity)`
  - `Display()` (virtual)

- `Clothing.cs`  
  Derived class from `Product`:
  - Extra field: `JeansName`
  - Overrides:
    - `GetTaxRate()` → 10%
    - `Display()` → adds jeans name

- `Grocery.cs`  
  Derived class from `Product`:
  - Extra field: `ExpiryDate`
  - Overrides:
    - `GetTaxRate()` → 2%
    - `Display()` → adds expiry date

- `Program.cs`  
  Main menu and user input handling:
  - Create Clothing or Grocery
  - Enter quantity
  - Display product information
  - Print total price with tax

---

## Tax Rules Used

### Product (Default Tax Rule)
- If `BasePrice >= 25000` → **15% tax**
- Else → **5% tax**

### Grocery Tax Rule (Override)
- Grocery has fixed **2% tax**

### Clothing Tax Rule (Override)
- Clothing has fixed **10% tax**

---

## How Calculation Works

1. Tax is calculated based on product type:
   - `taxAmount = BasePrice * GetTaxRate()`
2. Final unit price:
   - `finalUnitPrice = BasePrice + taxAmount`
3. Total price:
   - `total = finalUnitPrice * quantity`

---

## How to Run

1. Open the project in **Visual Studio** or **VS Code**
2. Build and run the program:
   - Visual Studio: `Start`
   - VS Code: `dotnet run`

---

## Sample Output (Example)
