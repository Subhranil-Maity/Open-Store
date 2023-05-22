namespace Open_Store{
    class Error
    {
        public static void SomeError(){
            Console.WriteLine("some error");
            Environment.Exit(-999);
        }
    }
}