namespace quiz_app;

class Question{
    public Question(string text, string[] choices, string answer){
        this.Text = text;
        this.Choices = choices;
        this.Answer = answer;
    }
    public string Text { get; set; }

    public string[] Choices { get; set; }

    public string Answer { get; set; }

    public bool checkAnswer(string answer){
        return this.Answer.ToLower() == answer.ToLower();
    }
}

class Quiz{

    public Quiz(Question[] questions)
    {
        this.Questions = questions;
        this.QuestionIndex = 0;
        this.Score = 0;
    }

    private Question[] Questions { get; set; }
    
    private int QuestionIndex { get; set; }

    private int Score { get; set; }

    private Question GetQuestion(){
        return this.Questions[this.QuestionIndex];
    }
    public void DisplayQuestion(){
        var question = this.GetQuestion();
        this.DisplayProgress();

        Console.WriteLine($"Question {this.QuestionIndex+1} : {question.Text}");
        foreach (var a in question.Choices)
            {
                Console.WriteLine($"- {a}");
            }
          Console.Write("Your answer : ");
        var answer = Console.ReadLine();
        this.Guess(answer);
    }

    private void Guess(string answer){
        var question = this.GetQuestion();
        

        if(question.checkAnswer(answer))
            this.Score++;

        this.QuestionIndex++;
        if(this.Questions.Length == this.QuestionIndex){
            this.DisplayScore();
        }
        else{
            Console.WriteLine("-------------------------------------------------");
            this.DisplayQuestion();
        }     
    }
    private void DisplayScore(){
        Console.WriteLine($"Score : {this.Score}");
    }
    private void DisplayProgress(){
        int totalQuestion = this.Questions.Length;
        int questionNumber = this.QuestionIndex+1;

        if(totalQuestion >= questionNumber)
            Console.WriteLine($"Question {questionNumber} / {totalQuestion}");
    }
}
class Program{



    static void Main(string[] args){
        var q1 = new Question("Identify the noun.\nI live in Amsterdam.", new string[]{"In", "Live", "Amsterdam", "I"}, "Amsterdam");
        var q2 = new Question("Identify the pronoun.\nThey were having dinner.", new string[]{"Dinner", "They", "Were", "Having"}, "They");
        var q3 = new Question("Identify the verb.\nThe monkey sat by the door.", new string[]{"Monkey", "By", "Door", "Sat"}, "Sat");

        var questions = new Question[]{q1, q2, q3};

        var quiz = new Quiz(questions);
        quiz.DisplayQuestion();
    }
}
