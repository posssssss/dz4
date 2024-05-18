using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz.cistKod
{
    //metoda tvornice
    public class WebElement
    {
        string name;
        public WebElement(string name)
        {
            Console.WriteLine($"Found {name}");
            this.name = name;
        }
        public void Click()
        {
            Console.WriteLine($"Clicked {name}");
        }
    }

    public interface ILoginPage
    {
        public WebElement loginButton();
        public WebElement usernameInput();
        public WebElement passwordInput();
    }

    public class ChromeLoginPage : ILoginPage
    {
        public WebElement loginButton()
        {
            return new WebElement("LoginButton");
        }
        public WebElement usernameInput()
        {
            return new WebElement("userInput");
        }

        public WebElement passwordInput()
        {
            return new WebElement("passwordElement");
        }
    }
    public class FirefoxLoginPage : ILoginPage
    {
        public WebElement loginButton()
        {
            return new WebElement("LoginButton");
        }
        public WebElement usernameInput()
        {
            return new WebElement("userInput");
        }

        public WebElement passwordInput()
        {
            return new WebElement("passwordElement");
        }
    }

    public abstract class LoginPageFactory
    {
        public abstract ILoginPage CreatePage();
    }
    public class ChromeLoginPageFactory:LoginPageFactory
    {
        public override ILoginPage CreatePage()
        {
            return new ChromeLoginPage();
        }
    }
    public class FirefoxLoginPageFactory : LoginPageFactory
    {
        public override ILoginPage CreatePage()
        {
            return new FirefoxLoginPage(); 
        }
    }
}
