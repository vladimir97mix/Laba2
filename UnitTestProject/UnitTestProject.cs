using System;
using NUnit.Framework;
using WinFormsAppLabTest;

namespace UnitTestProject
{
    public class Tests
    {
        /// <summary>
        /// ���������� ������ ��� �heckDoctorData.
        /// � ������� �������� ������ ������ � �������, ��������������� �����������.
        /// </summary>
        [TestCase("DoctorSuperBest123!")]
        [TestCase("DoctorSuperBest123$")]
        [TestCase("DoctorSuperBest13@")]
        [TestCase("DoctorSuperBest13#")]
        [TestCase("DoctorSuper$Best13")]
        [TestCase("DoctorSuperbest13%")]
        [TestCase("DoctorSuperBest13^")]
        [TestCase("DoctorSuperBes&t13")]
        [TestCase("Doctorsu*perBest13")]
        public void T_001_�heckDoctorData_BaseFlow(string value)
        {
            //���������� ������
            String login = "myname_doctor";
            String password = value;
            String repPassword = value;

            //��������� ��������            
            bool expectedReturnValue = true;

            //���������� ���������� ��� ����������� ��������
            bool actualReturnValue = false;

            //Assert ��� ��������� ����������
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = RegisterForm.checkDoctorData(login, password, repPassword);
            });

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }

        /// <summary>
        /// ������ �����.
        /// ������������ ������� ���� ����� ������ ������.
        /// </summary>
        [Test]
        public void T_002_�heckDoctorData_EmptyLogin()
        {
            //���������� ������
            String login = "";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSuperBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.EmptyLogin;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ ������ ������.
        /// ������������ ������� ���� ����� ������� �������� ������ ������.
        /// </summary>
        [Test]
        public void T_003_�heckDoctorData_EmptyPassword1()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "";
            String repPassword = "DoctorSuperBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.EmptyPassword1;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ ������ ������.
        /// ������������ ������� ���� ����� ������� �������� ������ ������.
        /// </summary>
        [Test]
        public void T_004_�heckDoctorData_EmptyPassword2()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123!";
            String repPassword = "";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.EmptyPassword2;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ �� ���������.
        /// ������������ ���� � ���� ������ ������ ������.
        /// </summary>
        [Test]
        public void T_005_�heckDoctorData_DifferentPasswords()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSupeBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.DifferentPasswords;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ����� � ������ ���������.
        /// ������������ ���� � ���� ������ � ������ ���� � �� �� ������.
        /// </summary>
        [Test]
        public void T_006_�heckDoctorData_SameLoginPassword()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "myname_doctor";
            String repPassword = "myname_doctor";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.SameLoginPassword;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ ����� 10 ��������.
        /// ������������ ���� ������ ����� 10 ��������.
        /// </summary>
        [Test]
        public void T_007_�heckDoctorData_PasswordLess10Chars()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "Doc123!";
            String repPassword = "Doc123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.PasswordLess10Chars;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ �� �������� ����.
        /// ������������ ���� ������ ��� ����.
        /// </summary>
        [Test]
        public void T_008_�heckDoctorData_PasswordNoNumber()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest!";
            String repPassword = "DoctorSuperBest!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.PasswordNoNumber;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ �� �������� ������������.
        /// ������������ ���� ������ ��� �������� �@#$%^&*!�.
        /// </summary>
        [Test]
        public void T_009_�heckDoctorData_PasswordNoExtraChar()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123";
            String repPassword = "DoctorSuperBest123";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.PasswordNoExtraChar;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ������ �� �������� ����� � ������� ��������.
        /// ������������ ���� ������ ��� ���� � ������� ��������.
        /// </summary>
        [Test]
        public void T_010_�heckDoctorData_PasswordNoUpperChar()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "doctorsuperbest123!";
            String repPassword = "doctorsuperbest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.PasswordNoUpperChar;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ����������� ������ ������.
        /// ����� �������� ����������� �������.
        /// </summary>
        [Test]
        public void T_011_�heckDoctorData_LoginForbidden()
        {
            //���������� ������
            String login = "myname_doctor!";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSuperBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.LoginForbidden;

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                RegisterForm.checkDoctorData(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        public class MockDoctorEntry : IDoctorEntry
        {
            public string ID { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class MockDatabaseController_NoConnection : IDatabaseController
        {
            public IDoctorEntry getNewDoctorEntry() { throw new NotImplementedException(); }

            public bool login(string login, string password) { throw new NotImplementedException(); }

            public bool tryConnectDB() { return false; }

            public bool tryCreateAccount(string login, string password) { throw new NotImplementedException(); }
        }

        public class MockDatabaseController_LoginExists : IDatabaseController
        {
            public IDoctorEntry getNewDoctorEntry() { throw new NotImplementedException(); }

            public bool login(string login, string password) { return true; }

            public bool tryConnectDB() { return true; }

            public bool tryCreateAccount(string login, string password) { return false; }
        }

        public class MockDatabaseController_OK : IDatabaseController
        {
            public IDoctorEntry getNewDoctorEntry() { return new MockDoctorEntry() { ID = "1", Login = "myname_doctor", Password = "DoctorSuperBest123!" }; }

            public bool login(string login, string password) { return true; }

            public bool tryConnectDB() { return true; }

            public bool tryCreateAccount(string login, string password) { return true; }
        }
        /// <summary>
        /// ����������� �������.
        /// ������� ����������� ��������.
        /// </summary>
        [Test]
        public void T_012_onRegisterClick_BasicFlow()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSuperBest123!";


            //���������� ������
            RegisterForm registerForm = new RegisterForm();
            registerForm.controller = new MockDatabaseController_OK();
            IDoctorEntry doctorEntry = null;

            //Assert ��� ��������� ����������
            Assert.DoesNotThrow(() =>
            {
                doctorEntry = registerForm.onRegisterClick(login, password, repPassword);
            });

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.IsNotNull(doctorEntry);
            Assert.AreEqual(doctorEntry.Login, login);
            Assert.AreEqual(doctorEntry.Password, password);
        }
        /// <summary>
        /// ���������� ����������� � ��.
        /// ��� ������� � ���� ������, ������� �� ����� ������������������.
        /// </summary>
        [Test]
        public void T_013_onRegisterClick_NoConnectionDB()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSuperBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.NoConnectionDB;

            RegisterForm registerForm = new RegisterForm();

            registerForm.controller = new MockDatabaseController_NoConnection();

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                registerForm.onRegisterClick(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ���������� ����������� � ��.
        /// ��� ������� � ���� ������, ������� �� ����� ������������������.
        /// </summary>
        [Test]
        public void T_014_onRegisterClick_LoginAlreadyExists()
        {
            //���������� ������
            String login = "myname_doctor";
            String password = "DoctorSuperBest123!";
            String repPassword = "DoctorSuperBest123!";

            //��������� ��������            
            String expectedExceptionMessage = RegisterForm.ExceptionStrings.LoginAlreadyExists;

            RegisterForm registerForm = new RegisterForm();

            registerForm.controller = new MockDatabaseController_LoginExists();

            //Assert ��� ��������� ����������
            Exception? exception = Assert.Throws<Exception>(() =>
            {
                registerForm.onRegisterClick(login, password, repPassword);
            });

            Assert.IsNotNull(exception);

            //Assert ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }
    }
}
