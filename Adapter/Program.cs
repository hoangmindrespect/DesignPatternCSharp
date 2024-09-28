using System;

namespace MinhHoangNguyen.DesignPattern.Adapter
{
    // Giao diện mà ứng dụng của chúng ta mong muốn sử dụng
    public interface ITarget
    {
        string Translate(string text);
    }

    // Lớp đã tồn tại cung cấp dịch vụ dịch ngôn ngữ nhưng có phương thức khác với yêu cầu
    // Adaptee
    public class GoogleTranslateService
    {
        public string GoogleTranslate(string text, string sourceLang, string targetLang)
        {
            // Giả sử đây là dịch vụ Google API trả về kết quả dịch
            return $"[Google Translated] {text} from {sourceLang} to {targetLang}";
        }
    }

    // Adapter sử dụng Composition
    public class ObjectAdapter : ITarget
    {
        private readonly GoogleTranslateService _googleTranslateService;

        public ObjectAdapter(GoogleTranslateService googleTranslateService)
        {
            this._googleTranslateService = googleTranslateService;
        }

        // Chuyển đổi từ giao diện mục tiêu sang lớp Adaptee
        public string Translate(string text)
        {
            // Chúng ta giả sử dịch từ tiếng Anh sang tiếng Việt
            return _googleTranslateService.GoogleTranslate(text, "en", "vi");
        }
    }

    // Adapter sử dụng Inheritance
    public class ClassAdapter : GoogleTranslateService, ITarget
    {
        // Chuyển đổi từ giao diện mục tiêu sang lớp Adaptee
        public string Translate(string text)
        {
            // Giả sử dịch từ tiếng Anh sang tiếng Việt
            return GoogleTranslate(text, "en", "vi");
        }
    }

    // Sử dụng Object Adapter
    class Program
    {
        static void Main(string[] args)
        {
            // Composition
            GoogleTranslateService googleTranslateService = new GoogleTranslateService();
            ITarget cTranslator = new ObjectAdapter(googleTranslateService);

            string cTranslatedText = cTranslator.Translate("Hello");
            Console.WriteLine(cTranslatedText);

            // Inheritance
            ITarget iTranslator = new ClassAdapter();

            string iTranslatedText = iTranslator.Translate("Goodbye");
            Console.WriteLine(iTranslatedText);
        }
    }
}