string secretWord = "orange";
char[] guessWord = new char[secretWord.Length];

for (int i = 0; i < guessWord.Length; i++)
{
    guessWord[i] = '_';
}

int attempts = 6;
bool wordGuessed = false;

//attempts 횟수만큼 추론
for (int i = 0; i < attempts; attempts--)
{
    Console.Write(new string(guessWord) + $" guess the word! (you have {attempts} chance) : ");
    string input = Console.ReadLine();
    // 문자 1개 입력시 맞출 단어에 포함되면 guessTemp에 입력
    if (input.Length == 1)
    {
        char guessTemp = input[0];
        //문자가 secretWord에 포함되는지 확인
        if (secretWord.Contains(guessTemp))
        {
            //포함되면 guessWord에 있는지 확인. 중복되면 attempts만 차감
            if (!guessWord.Contains(guessTemp))
            {
                //중복이 아니면 guessword에 단어 입력
                for (int j = 0; j < secretWord.Length; j++)
                {
                    if (secretWord[j] == guessTemp)
                        guessWord[j] = guessTemp;
                }
                //guessWord가 완성되었을 경우
                if (Enumerable.SequenceEqual(guessWord, secretWord.ToCharArray()))
                {
                    Console.WriteLine("Congratulations! You answered correctly.");
                    break;
                }

            }
        }
    }
    // input의 길이가 secretWord의 문자열 길이와 동일
    else if (input.Length == secretWord.Length)
    {
        //정답
        if (string.Equals(input, secretWord))
        {
            guessWord = secretWord.ToCharArray();
            Console.WriteLine("Congratulations! You answered correctly.");
            break;
        }
        //오답
        else
        {
            Console.WriteLine("You are wrong.");
        }
    }
    // input의 길이가 한 문자도 아니고 secretWord의 문자열 길이와도 다름
    else
    {
        Console.WriteLine("Enter one character or match it to the length of the secret word.");
    }
}
//추론 끝

//실패.
if (guessWord.Contains('_'))
{
    Console.WriteLine("You are lose. This is your final reasoning word. " + new string(guessWord));
}