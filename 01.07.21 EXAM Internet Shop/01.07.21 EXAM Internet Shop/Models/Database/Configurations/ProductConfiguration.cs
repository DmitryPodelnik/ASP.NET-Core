using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
              new Product[]
              {
                  new Product { Id = 1, Name = "Laptop Asus ROG Strix G15 G512LI-HN087 (90NR0381-M01330) Original Black", Content = "Видеокарта NVIDIA Geforce RTX 30-й серии"
                                + "Используя графический процессор с микроархитектурой Ampere, представляющей 2-ое поколение " +
                                "чипов NVIDIA RTX, видеокарты GeForce RTX 30-й серии готовы обеспечить фантастическую игровую " +
                                "производительность за счет улучшенных вычислительных блоков: RT-ядер, тензорных ядер и потоковых " +
                                "мультипроцессоров. Они поддерживают трассировку лучей в режиме реального времени и передовые " +
                                "технологии искусственного интеллекта.",
                                Price = 1500, Image = "1.jpg", Seller = "ROZETKA" },
                  new Product { Id = 2, Name = "Laptop Asus VivoBook X712FA-BX665 (90NB0L61-M15620) Transparent Silver", Content = "Видеокарта NVIDIA Geforce RTX 30-й серии"
                                + "Используя графический процессор с микроархитектурой Ampere, представляющей 2-ое поколение " +
                                "чипов NVIDIA RTX, видеокарты GeForce RTX 30-й серии готовы обеспечить фантастическую игровую " +
                                "производительность за счет улучшенных вычислительных блоков: RT-ядер, тензорных ядер и потоковых " +
                                "мультипроцессоров. Они поддерживают трассировку лучей в режиме реального времени и передовые " +
                                "технологии искусственного интеллекта.",
                                Price = 1800, Image = "2.jpg", Seller = "ROZETKA" },
                  new Product { Id = 3, Name = "Laptop Asus ZenBook Flip UX363JA-EM120T (90NB0QT1-M04710) Pine Grey", Content = "Видеокарта NVIDIA Geforce RTX 30-й серии"
                                + "Используя графический процессор с микроархитектурой Ampere, представляющей 2-ое поколение " +
                                "чипов NVIDIA RTX, видеокарты GeForce RTX 30-й серии готовы обеспечить фантастическую игровую " +
                                "производительность за счет улучшенных вычислительных блоков: RT-ядер, тензорных ядер и потоковых " +
                                "мультипроцессоров. Они поддерживают трассировку лучей в режиме реального времени и передовые " +
                                "технологии искусственного интеллекта.",
                                Price = 1300, Image = "3.jpg", Seller = "ROZETKA" },
                  new Product { Id = 4, Name = "Laptop Asus ROG Strix G15 G513QE-HN046 (90NR05I1-M01570) Original Black", Content = "Видеокарта NVIDIA Geforce RTX 30-й серии"
                                + "Используя графический процессор с микроархитектурой Ampere, представляющей 2-ое поколение " +
                                "чипов NVIDIA RTX, видеокарты GeForce RTX 30-й серии готовы обеспечить фантастическую игровую " +
                                "производительность за счет улучшенных вычислительных блоков: RT-ядер, тензорных ядер и потоковых " +
                                "мультипроцессоров. Они поддерживают трассировку лучей в режиме реального времени и передовые " +
                                "технологии искусственного интеллекта.",
                                Price = 1900, Image = "4.jpg", Seller = "ROZETKA" },
                  new Product { Id = 5, Name = "Ноутбук MSI GL65 Leopard 10SCSR (GL6510SCSR-077XUA ) Black", Content = "Ускоряйте свою игру!"
                                + "Переключайтесь между играми и работой, не сбрасывая скорость ни на секунду! " +
                                "Графическая подсистема ноутбука основана на видеокарте GeForce, гарантирующей плавную " +
                                "картинку в современных играх, а высокой производительности в широком спектре других " +
                                "приложений способствуют мощный процессор Intel Core 10-го поколения, дополненный быстрой памятью DDR4.",
                                Price = 1000, Image = "2.jpg", Seller = "ROZETKA" },
                  new Product { Id = 6, Name = "Laptop Asus ROG Zephyrus G14 GA401QE-HZ090T (90NR05R6-M01320) Eclipse Gray", Content = "Куда бы дорога вас ни привела"
                                + "Модель ThinkPad X1 Carbon (7th Gen) на 6% тоньше, чем ее предшественница. " +
                                "Толщина этого ноутбука — 14.95 мм, а вес составляет всего немного больше 1-го кг." +
                                " Благодаря этой невероятной легкости ноутбука вы больше не будете привязаны к офису. " +
                                "Время автономной работы достигает 18.3 часа, поэтому вы можете брать ноутбук с собой куда угодно.",
                                Price = 1500, Image = "6.jpg", Seller = "ROZETKA" },
              });
        }
    }
}
