using System.Data.Odbc;

namespace Models.Entitis
{
    public class Animal
    {
        public long id { get; set; } //идентификатор
        public long[] animalTypes { get; set; } //массив id типов животных
        public float weight { get; set; } //вес
        public float lenght { get; set; } //длина
        public float height { get; set; } //высота
        public string gender { get; set; } //гендер (MALE or FEMALE or OTHER) /*attackHelicopter*/
        public string lifeStatus { get; set; } //жизненный статус (ALIVE or DEAD)
        public DateTime chippingDateTime { get; set; } //дата чипирования
        public int chipperId { get; set; } //пользователь, чипировавший животное
        public long chippingLocationId { get; set; } //место чипирования
        public long[]? visitedLocations { get; set; } //массив посещённых мест
        public DateTime deathDateTime { get; set; } //дата смерти (if lifeStatus == "DEAD")
    }
}
