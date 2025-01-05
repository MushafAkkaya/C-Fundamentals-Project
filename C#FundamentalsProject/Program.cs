Console.WriteLine("Aşağıdaki programlardan hangisini çalıştırmak istersiniz?" +
    " Çalıştırmak istediğiniz programın başındaki rakamı giriniz:");
Console.WriteLine("1 - Rastgele Sayı Bulma Oyunu");
Console.WriteLine("2 - Hesap Makinesi");
Console.WriteLine("3 - Ortalama Hesaplama");
string project = Console.ReadLine(); //Kullanıcıya hangi uygulamayı seçmeyi istediği soruldu ve cevabı alındı.

if (project == null || project == "") //Buradaki if scope'larında kullanıcının seçimine göre kontroller yapılıp ilgili metodlara yönlendirme yapıldı.
{
    Console.WriteLine("Program seçmek için bir değer girmediniz.");
}
else if (project.Length > 1)
{
    Console.WriteLine("Sadece tek bir değer girmeniz gerekmektedir!");
}
else if (project.Contains("1"))
{
    FindRandomNumber(); //Rastgele sayı tahmin metodunu çağıran satır.
}
else if (project.Contains("2"))
{
    Calculator(); // Hesap makinesi metodunu çağıran satır.
}
else if (project.Contains("3"))
{
    CalculateAverage(); // Ortalama hesaplama metodunu çağıran satır.
}
else
    Console.WriteLine("Geçerli bir değer giriniz.");

void FindRandomNumber()
{
    Random random = new Random();
    int randomNumber = random.Next(1, 101); //Random sınıfı kullanılarak 1 ile 100 arasında rastgele sayı oluşturur.
    Console.WriteLine("*** Rastgele Sayı Tahmin Oyununa Hoşgeldiniz ***");
    Console.WriteLine("1 ile 100 arasından rastgele belirlenen sayıyı tahmin edin(Toplam tahmin hakkınız 5)."); //Kullanıcıdan bu sayıyı tahmin etmesi istendi.
    int guessCount = 5;
    while (guessCount > 0)
    {
        Console.WriteLine(guessCount + " tahmin hakkınız kaldı. Tahmin ettiğiniz sayıyı giriniz:");
        int guessNumber = Convert.ToInt32(Console.ReadLine());

        if (guessNumber >= 1 && guessNumber <= 100) //Kullanıcının sayıyı doğru aralıkta girdiğinin kontrolü
        {
            if (guessNumber == randomNumber) //Sayı doğru aralıkta girildi ise içerideki if scope'ları kontrol edilir ve verilen tahmine göre kullanıcıya kalan hakkı bitene kadar ipucu verilerek yanıt döndürülür.
            {
                Console.WriteLine("Tebrikler sayıyı doğru tahmin ettiniz!"); //Sayı doğru tahmin edildiyse döngüden çıkılarak kullanıcı tebrik edilir ve oyun biter.
                break;
            }
            else if (guessNumber > randomNumber)
            {
                Console.WriteLine("Tahmin ettiğiniz sayı rastgele sayıdan büyük. Lütfen daha küçük bir sayı deneyin.");
            }
            else if (guessNumber < randomNumber)
            {
                Console.WriteLine("Tahmin ettiğiniz sayı rastgele sayıdan küçük. Lütfen daha büyük bir sayı deneyin.");
            }

            guessCount -= 1; //Her tahminden sonra tahmin hakkı 1 azaltılır ve 5 kez ile sınırlandırılacak şekilde döngüye geri sokulur.

            if (guessCount == 0)
            {
                Console.WriteLine("Tahmin etme hakkınız doldu ve doğru sayıyı bulmayı başaramadınız. Doğru sayı: " + randomNumber);
            }
        }
        else
            Console.WriteLine("Lütfen 1 ile 100 arasında bir sayı girin(1 ve 100 dahil).");// Kullanıcı sayıyı doğru aralıkta girmediyse bilgisi verilir.
    }
    Console.WriteLine("Oyun tamamlandı. Tekrar oynamak için programı yeniden başlatabilirsiniz.");
}

void Calculator()
{
    Console.WriteLine("*** Hesap Makinesine Hoşgeldiniz ***");
    Console.WriteLine("Burada belirteceğiniz 2 farklı sayı ile toplama, çıkarma, çarpma ve bölme işlemleri yapabilirsiniz.");
    Console.WriteLine("İlk sayıyı girin");
    double firstNumber = Convert.ToInt32(Console.ReadLine()); //Kullanıcıdan ilk sayıyı girmesi istenir ve burada sayı yakalanır.
    Console.WriteLine("İkinci sayıyı girin");
    double secondNumber = Convert.ToInt32(Console.ReadLine());//Kullanıcıdan ikinci sayıyı girmesi istenir ve burada sayı yakalanır.
    Console.WriteLine("Şimdi bu sayılar ile hangi işlemi yapmak istediğinizi seçin:");
    Console.WriteLine("Toplama için: +\nÇıkarma için: -\nÇarpma için: *\nBölme için: /");
    char process = Convert.ToChar(Console.ReadLine()); //Kullanıcıya hangi işlemi yapmak istediği sorulur ve cevabı burada yakalanır. Girilen değerler char'a çevirilir.
    double result = 0;
    switch (process) //Kullanıcının seçimine göre aşağıdaki case'lere girerek sonuç ekrana yazdırılır.
    {
        case '+':
            result = firstNumber + secondNumber;
            Console.WriteLine("Sonuç: " + result);
            break;

        case '-':
            result = firstNumber - secondNumber;
            Console.WriteLine("Sonuç: " + result);
            break;

        case '*':
            result = firstNumber * secondNumber;
            Console.WriteLine("Sonuç: " + result);
            break;

        case '/':
            if (secondNumber != 0) //Bölme işlemine özel sıfıra bölünme durumu kontrol edilir.
            {
                result = firstNumber / secondNumber;
                Console.WriteLine("Sonuç: " + result);
            }
            else
                Console.WriteLine("Hata!: Herhangi bir sayı sıfıra bölünemez."); //Eğer ikinci sayı 0 seçilmiş ise bölünme olamayacağı kullanıcıya belirtilir.
            break;

        default:
            Console.WriteLine("Geçersiz bir işlem girdiniz!"); //4 işlem dışında farklı bir değer girilir ise kullanıcıya belirtilir.
            break;
    }
    Console.WriteLine("Başka bir işlem yapmak isterseniz programı yeniden başlatabilirsiniz.");
}

void CalculateAverage()
{
    Console.WriteLine("*** Ortalama Hesaplamaya Hoşgeldiniz ***");
    Console.WriteLine("Burada gireceğiniz 3 farklı ders notunuz ile ortalamanızı hesaplayabilirsiniz!");

    Console.WriteLine("Birinci ders notunuzu giriniz: ");
    double firstScore = Convert.ToDouble(Console.ReadLine()); //Kullanıcıdan birinci ders notu alınır ve double'a çevirilir.

    Console.WriteLine("İkinci ders notunuzu giriniz: ");
    double secondScore = Convert.ToDouble(Console.ReadLine());//Kullanıcıdan ikinci ders notu alınır ve double'a çevirilir.

    Console.WriteLine("Üçüncü ders notunuzu giriniz: ");
    double thirdScore = Convert.ToDouble(Console.ReadLine());//Kullanıcıdan üçüncü ders notu alınır ve double'a çevirilir.

    if ((firstScore !< 0 && firstScore !> 100) || (secondScore !< 0 && secondScore !> 100) || (thirdScore !< 0 && thirdScore !> 100)) //Girilen notlar 0-100 arasında mı kontrolü yapılır eğer doğruysa işleme devam edilir.
    {
        double result = (firstScore + secondScore + thirdScore) / 3; //Girilen notların ortalaması hesaplanır ve ekrana yazdırılır.
        Console.WriteLine("Ortalama notunuz: " + result);
        if (result >= 90) //Ard arda yer alan if scope'larında ortalama hangi aralıkta ise kontroller yapılır ve harf karşılığı gösterilir.
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: AA");
        }
        else if (result >= 85 && result <90)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: BA");
        }
        else if (result >= 80 && result < 85)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: BB");
        }
        else if (result >= 75 && result < 80)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: CB");
        }
        else if (result >= 70 && result < 75)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: CC");
        }
        else if (result >= 65 && result < 70)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: DC");
        }
        else if (result >= 60 && result < 65)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: DD");
        }
        else if (result >= 55 && result < 60)
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: FD");
        }
        else
        {
            Console.WriteLine("Ortalama notunuzun harf karşılığı: FF");
        }
    }
    else
        Console.WriteLine("Girmiş olduğunuz notlar 0-100 aralığında olmalıdır. Lütfen kontrol ediniz."); //0-100 arasında değer girilmez ise kullanıcıya bildirilir.
    Console.WriteLine("Ortalama notunuzu hesaplamayı tamamladınız. Tekrar hesaplamak isterseniz programı yeniden başlatabilirsiniz.");
}