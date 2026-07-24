using OOP.Abstract;
using OOP.@interface;

IPayment payment = new MomoPayment();
payment.pay();

payment = new CashPayment();
payment.pay();

payment = new BankPayment();
payment.pay();

//payment = new IPayment(); Lỗi complier: Cannot create an instance of the interface 'IPayment' because it is an interface and cannot be instantiated directly.
//payment.pay();

//Animal animal = new Animal(); Lỗi complier: Cannot create an instance of the abstract class 'Animal' because it is abstract and cannot be instantiated directly.
Animal cat = new Cat();
cat.makeSound();
cat.sleep();
cat.stop();