// // Online C# Editor for free
// // Write, Edit and Run your C# code using C# Online Compiler

// using System;
// interface Icamera{
//     void capturephoto();
//     void recordvideo();
// }
// abstract class Mobile{
//     public abstract void processor();
//     public void calling(){
//         Console.WriteLine("calling ....");
//     }
// }
// class Samsung : Mobile , Icamera{
//     public override  void processor(){
//         Console.WriteLine("Snapdragon 950");
//     }
//     public void capturephoto(){
//         Console.WriteLine("Samsung is clicking photo");
//     }
//     public void recordvideo(){
//         Console.WriteLine("samasung is recording video");
//     }
// }
// class Iphone : Mobile , Icamera{
//     public override  void processor(){
//         Console.WriteLine("Ios : 18");
//     }
//     public void capturephoto(){
//         Console.WriteLine("iphone is capturing photo");
//     }
//     public void recordvideo(){
//         Console.WriteLine("Iphone is recording video");
//     }
// }
// abstract class shape{
//     public abstract void draw();
// }
// //---------------------------------------sealed method-------
// class A{
//     public virtual void show(){
//         Console.WriteLine("Hewloo from A");
//     }
// }
// class B : A{
//     public sealed override void show(){
//         Console.WriteLine("Hellow from B");
//     }
// }
// class C : A{
//     public override void show(){
//         Console.WriteLine("Hellow from c");
//     }
// }
// //----------------------------------------------------
// class Animal{
//     public virtual  void sound(){
//         Console.WriteLine("Animal sound--");
//     }
// }
// class Dog : Animal{
//     public override  void sound(){
//         Console.WriteLine(" Dog soundss : Bark Bark Bark,,,");
//     }
// }
// //-------------------------------------compostion-----------------------------
// class Heart{
//     public void pump(){
//         Console.WriteLine("pumpingg");
//     }
// }
// class Human{
//     private Heart heart;
//     public Human(){
//         heart = new Heart();
//     }
//     public void live(){
//         heart.pump();
//         Console.WriteLine("human is live");
//     }
// }
// //----------------------------------------------------------------
// class Employee{
//     private int salary ;
//     public int Salary{
//         get { return salary*2;}
//         set{
//             if(value<0) throw new Exception("Invalid Salary");
//             salary = value;
//         }
//     }
// }
// //---------------------------------inheritence-------------------------------
// class Parent{
//     public virtual void  greet(){
//         Console.WriteLine("Hello from parent");
//     }
// }
// class Child : Parent{
//     public  override void greet(){
//         Console.WriteLine("hello from child");
//     }
//     public void display(){
//         Console.WriteLine("hiiii harman");
//     }
// }
// class Child2:Parent{
//     public override void greet(){
//         Console.WriteLine("hello from child 2");
//     }
//     public void display(){
//         Console.WriteLine("hiiii");
//     }
// }
// //---------------------------------aggregation-----------------
// class Engine{
//     public void Enginestart(){
//         Console.WriteLine("Engine startss");
//     }
// }
// class Car {
//     private Engine engine;
//     public Car(Engine engine){
//         this.engine= engine;
//     }
//     public void startCar(){
//         engine.Enginestart();
//         Console.WriteLine("Car is running");
//     }
// }
// //---------------------------------------------------------------------
// public class HelloWorld
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine ("Try programiz.pro");
//         Employee e1 = new Employee();
        
//         try{ 
//             Console.WriteLine(e1.Salary);
            
//              Parent p1 = new Parent();
//              p1.greet();
//              Child p2 = new Child();
//             p2.greet();
//             p2.display();
//             Child2 p3 = new Child2();
//             p3.greet();
//             p3.display();
//             //----------------------aggregation----
//             Engine e = new Engine();
//             Car c  = new Car(e);
//             c.startCar();
//             //================
//              Heart he = new Heart();
//              he.pump();
//             Human hu  =new Human();
//             hu.live();
//             //=================
//             Animal aini = new Animal();
//             Animal bini = new Dog();
//             Dog cini  = new Dog();
//             aini.sound();
//             bini.sound();
//             cini.sound();
//             //-------------------------
//             A arjan = new A();
//             arjan.show();
//             A karan = new B();
//             karan.show();
//             A aujla = new C();
//             aujla.show();
//             //----------------------
//             Mobile mob = new Samsung();
//             mob.calling();
//             Samsung j10 = new Samsung();
//             j10.processor();
//             j10.capturephoto();
//             Iphone iphone17  =new Iphone();
//             iphone17.processor();
//             iphone17.capturephoto();
//             iphone17.recordvideo();
//             e1.Salary = 20000;
//              Console.WriteLine(e1.Salary);
//              int p=10;
//              p=p++ + ++p;
//              Console.WriteLine(p is object);
//              object a = 10;
//               object b = 10;
//               Console.WriteLine(ReferenceEquals(a, b));

             
            
//         }
//         catch(Exception ex){
//             throw new Exception(ex.Message);
//         }
//         finally{
//             Console.WriteLine("Code Executed sucessfully");
//         }
//     }
// }