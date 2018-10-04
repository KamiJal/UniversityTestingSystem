namespace UniversityTestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTestsTestQuestions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tests (Name, AddedDate, SubjectId) VALUES (N'Термодинамика', N'2018-10-04 00:00:00', 3)");

            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Тепловой двигатель за один цикл получает от нагревателя 100 кДж теплоты и отдает холодильнику 60 кДж. Чему равен КПД этого двигателя (%)?', N'60', N'67', N'40', N'25', 'C')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Каким должно быть отношение масс m1/m2 горячей и холодной воды для того, чтобы за счет охлаждения от 50°С до 30°С воды массы m1, вода массой m2 нагрелась от 20° до 30°С?', N'4', N'2', N'1', N'1/2', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Тепловой двигатель с КПД 50% за один цикл отдает холодильнику 56 кДж теплоты. Какая работа им (кДж) совершается за один цикл?', N'40', N'28', N'21', N'56', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Найдите работу, совершаемую двумя молями идеального газа при его изобарном нагревании на 100°С (Дж). R=8,3Дж/моль•К.', N'166', N'83', N'830', N'1660', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Какому количеству теплоты (МДж) эквивалентна работа, совершаемая за 1 ч двигателем мощностью 2 кВт?', N'0,2', N'2', N'3,6', N'7,2', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'При изохорном нагревании на 50 K идеальный газ получил 2 кДж теплоты. Какую работу совершил идеальный газ (Дж)?', N'0,8', N'1', N'2', N'0', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Какой должна быть температура холодильника тепловой машины (°С), чтобы максимальное значение КПД равнялось 50%? Температура нагревателя 327°С.', N'35', N'327', N'27', N'260', 'C')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Температура нагревателя реальной тепловой машины 227°С, холодильника - +27°С. За один цикл газ получает от нагревателя 64 кДж теплоты, а отдает холодильнику 48 кДж. Определите КПД машины (%).', N'35', N'25', N'15', N'40', 'B')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Какой процесс называется изотермическим? Процесс, происходящий…', N'при постоянной температуре', N'при постоянном давлении', N'при постоянном объеме', N'при постоянной теплоемкости', 'A')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Внутренняя энергия заданной массы m идеального газа зависит только от …', N'объема', N'давления', N'формы сосуда', N'температуры', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'В воду температурой 15°С и объемом 2 л опустили неизвестный сплав массой 1 кг и температурой 90°С. В результате теплообмена установилась температура 20°С. Какова удельная теплоемкость сплава (Дж/кг•К), если удельная теплоемкость воды равна 4200 Дж/кг•К?', N'400', N'600', N'1100', N'1300', 'B')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'На сколько мегаджоулей отличается внутренняя энергия 2 кг водяного пара при температуре 100°С от внутренней энергии 2 кг воды при этой же температуре? Lв=2,3 МДж/кг', N'на 4,6 МДж больше', N'на 2,3 МДж больше', N'не отличаются', N'на 2,3 МДж меньше', 'A')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Сколько льда (кг) растает, если лед массой 5 кг и температурой 0°С опустить в воду массой 10 кг и температурой 0°С?', N'3', N'2', N'1', N'0', 'D')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N' Взято по одному молю гелия, неона и аргона при одинаковой температуре. У какого газа внутренняя энергия самая большая?', N'у всех газов одинакова', N'у аргона', N'у гелия', N'у неона', 'A')");
            Sql("INSERT INTO TestQuestions(TestId, Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer) VALUES (1 , N'Укажите единицу измерения величины, измеряемой произведением pΔV.', N'ватт', N'паскаль', N'литр', N'джоуль', 'D')");
        }
        
        public override void Down()
        {
        }
    }
}
