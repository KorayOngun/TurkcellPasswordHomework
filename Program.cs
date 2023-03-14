internal class Program
{
    private static void Main(string[] args)
    {
        string password = Console.ReadLine();   
        string result = new CheckPassword(password).Control();
        Console.WriteLine(result);
        Console.ReadKey();
    }
}


class CheckPassword
{
    private string _password;
    private string _result;


    private List<bool> _success;
    // _success[0] = isLetter
    // _success[1] = isDigit
    // _success[2] = isNonAlphanumeric



    public CheckPassword(string password)
    {
       _password = password;    
       _password = _password.Replace(" ","");
    }
    public string Control()
    {
        if (!PasswordLength()) return "şifre kısa";

        // _success[0] = isLetter
        // _success[1] = isDigit
        // _success[2] = isNonAlphanumeric
        _success = new List<bool> { false, false, false };
        _success[0] = LetterControl();
        _success[1] = NumberControl();
        _success[2] = NonAlphanumericControl();

        return Result();
    }

    private string Result()
    {
        switch (_success.Count(x => x == true))
        {
            case 1:
                _result = "zayıf şifre";
                break;
            case 2:
                _result = "orta  şifre";
                break;
            case 3:
                _result = "güçlü  şifre";
                break;
            default:
                _result = "farklı şifre deneyin";
                break;
        }
        return _result;
    }

    private bool PasswordLength()
    {
        return _password.Length > 5;
    }
    private bool LetterControl()
    {
        foreach (char c in _password)
        {
            if (char.IsLetter(c)) return true;
        }
        return false;
    }
    private bool NumberControl()
    {
        foreach (char c in _password)
        {
            if (char.IsNumber(c)) return true;
        }
        return false;
    }
    private bool NonAlphanumericControl()
    {
        foreach (char c in _password)
        {
            if (!char.IsLetterOrDigit(c)) return true;
        }
        return false;
    }
}