
using System;

namespace EETMS_BusinessLayer.Validation
{
    public sealed class clsValidation
    {

        private static bool _IsThePasswordCountGratherThanEight(string Password)
       => Password.Length >= 8;

        private static bool _IsThePasswordHasTheSymbolGratherThanTwo(string Password)
        {
            int countTheSymbolInThePassword = 0;

            foreach (char CharacterPass in Password)
                if (char.IsSymbol(CharacterPass) || char.IsPunctuation(CharacterPass)) ++countTheSymbolInThePassword;

            return countTheSymbolInThePassword >= 2;
        }

        private static bool _IsThePasswordHasTheLowerLetterGratherThanTwo(string Password)
        {
            int countTheLetterInThePassword = 0;

            foreach (char CharacterPass in Password)
                if (Char.IsLower(CharacterPass)) ++countTheLetterInThePassword;

            return countTheLetterInThePassword >= 2;
        }

        private static bool _IsThePasswordHasTheUpperLetterGratherThanTwo(string Password)
        {
            int countTheLetterUpperInThePassword = 0;

            foreach (char CharacterPass in Password)
                if (Char.IsUpper(CharacterPass)) ++countTheLetterUpperInThePassword;

            return countTheLetterUpperInThePassword >= 2;
        }

        private static bool _IsThePasswordHasTheDigitsGratherThanThree(string Password)
        {
            int countTheDigitsInThePassword = 0;

            foreach (char CharacterPass in Password)
                if (Char.IsDigit(CharacterPass)) ++countTheDigitsInThePassword;

            return countTheDigitsInThePassword >= 3;
        }

        public static bool IsHasTheSymbolAndNumberAndLetters(string Password)
        {
            if (!String.IsNullOrEmpty(Password))
                if (_IsThePasswordCountGratherThanEight(Password))
                {

                    return (

                        _IsThePasswordHasTheSymbolGratherThanTwo(Password) &&
                        _IsThePasswordHasTheLowerLetterGratherThanTwo(Password) &&
                        _IsThePasswordHasTheUpperLetterGratherThanTwo(Password) &&
                        _IsThePasswordHasTheDigitsGratherThanThree(Password)
                        );
                }


            return false;
        }

        private static bool _IsValidEmailAddress(string EmailAddress)
        {

            if (string.IsNullOrEmpty(EmailAddress))
                return false;

            try
            {
                var Email = new System.Net.Mail.MailAddress(EmailAddress);
                return Email.Address == EmailAddress;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsValidEmailAddress(string EmailAddress)
            => _IsValidEmailAddress(EmailAddress);

        private static bool _CheckTheNameHaveDigit_SymbolOrPunctuation(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return true;

            foreach (char Character in Text)
                if (Char.IsDigit(Character) || Char.IsSymbol(Character) || Char.IsPunctuation(Character) || Char.IsWhiteSpace(Character)) return true;

            return false;
        }

        public static bool CheckTheNameHaveDigit_SymbolOrPunctuation(string Text)
            => _CheckTheNameHaveDigit_SymbolOrPunctuation(Text);

        private static bool _IsTheUsernameStartedDigits(char FirstCharacterUsername)
        => Char.IsDigit(FirstCharacterUsername);

        public static bool IsTheUsernameStartedDigits(char FirstCharacterUsername)
            => _IsTheUsernameStartedDigits(FirstCharacterUsername);

    }
}
