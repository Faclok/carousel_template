using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel
{
    public static class HTMLProperties
    {

        public const string SCRIPT = "<script>\r\n\r\n\r\n      const carousel = document.querySelector(\".carousel_faclok\");\r\n      let carouselItems = document.querySelectorAll(\".carousel__item\");\r\n      const [btnLeftCarousel, btnRightCarousel] = document.querySelectorAll(\r\n        \".carousel-button\"\r\n      );\r\n      let carouselCount = carouselItems.length;\r\n      let pos = 0;\r\n      let translateX = 0;\r\n\r\n      btnLeftCarousel.addEventListener(\"click\", (e) => {\r\n        let calculate = pos > 0 ? (pos - 1) % carouselCount : carouselCount;\r\n        if (pos > 0) translateX = pos === 1 ? 0 : translateX - 100;\r\n        else if (pos <= 0) {\r\n          translateX = 100 * (carouselCount - 1);\r\n          calculate = carouselCount - 1;\r\n        }\r\n\r\n        pos = slide({\r\n          show: calculate,\r\n          disable: pos,\r\n          translateX: translateX\r\n        });\r\n      });\r\n\r\n      btnRightCarousel.addEventListener(\"click\", (e) => {\r\n        let calculate = (pos + 1) % carouselCount;\r\n        if (pos >= carouselCount - 1) {\r\n          calculate = 0;\r\n          translateX = 0;\r\n        } else {\r\n          translateX += 100;\r\n        }\r\n\r\n        pos = slide({\r\n          show: calculate,\r\n          disable: pos,\r\n          translateX: translateX\r\n        });\r\n      });\r\n\r\n      function slide(options) {\r\n        function active(_pos) {\r\n          carouselItems[_pos].classList.toggle(\"active\");\r\n        }\r\n\r\n        function inactive(_pos) {\r\n          carouselItems[_pos].classList.toggle(\"active\");\r\n        }\r\n\r\n        inactive(options.disable);\r\n        active(options.show);\r\n\r\n        document.querySelectorAll(\".carousel__item\").forEach((item, index) => {\r\n          if (index === options.show) {\r\n            item.style.transform = `translateX(-${options.translateX}%) scale(1)`;\r\n          } else {\r\n            item.style.transform = `translateX(-${options.translateX}%) scale(1)`;\r\n          }\r\n        });\r\n\r\n        return options.show;\r\n      }\r\n    </script>";

        private const string START_BODY = "<div class=\"container_faclok\">\r\n      <div class=\"carousel_faclok\">";

        private const string END_BODY = "</div>\r\n      <div class=\"carousel__buttons\">\r\n        <button type=\"button\" class=\"carousel-button\">&#10094;</button>\r\n        <button type=\"button\" class=\"carousel-button\">&#10095;</button>\r\n      </div>\r\n    </div>";

        private const string IMG_PATTERN = "<div class=\"carousel__item {0}\">\r\n         <img style=\"width: 100%; height: 100%; object-fit: cover;\" src=\"{1}\" />\r\n        </div>";

        private const string START_STYLE = "   <style>\r\n      * {\r\n        margin: 0;\r\n        padding: 0;\r\n        font-family: sans-serif;\r\n        box-sizing: border-box;\r\n      }\r\n\r\n      .container_faclok {\r\nwidth: 100%;\r\n        display: flex;\r\n        flex-direction: column;\r\n        justify-content: center;\r\n        align-items: center;\r\n      }\r\n      .carousel__buttons {\r\n        width: 80%;\r\n        margin: 10px 0;\r\n        display: flex;\r\n      }\r\n      .carousel__buttons .carousel-button:focus {\r\n        background-color: rgb(154, 163, 247);\r\n      }\r\n      .carousel__buttons .carousel-button:hover {\r\n        background-color: #ddd;\r\n      }\r\n      .carousel__buttons .carousel-button:not(:nth-last-child()) {\r\n        margin-right: 10px;\r\n      }\r\n      .carousel__buttons .carousel-button {\r\n        font-size: 1rem;\r\n        margin-right: 10px;\r\n        box-shadow: 0 4px 8px #eee;\r\n        padding: 0.5rem 0.8rem;\r\n        cursor: pointer;\r\n        border: 1px solid #ddd;\r\n        color: #454545;\r\n        border-radius: 50%;\r\n        height: 40px;\r\n        width: 40px;\r\n        display: flex;\r\n        justify-content: center;\r\n        align-items: center;\r\n        outline: none;\r\n      }\r\n\r\n      .carousel_faclok {\r\n        width: 100%;\r\nheight: 440px;\r\n        border: 1px solid rgb(206, 206, 206);\r\n        overflow: hidden;\r\n        display: grid;\r\n        border-radius: 5px;\r\n        box-shadow: 0 4px 8px #eee;\r\n        grid-template-columns: repeat(";

        private const string END_STYLE = ", 100%);\r\n      }\r\n      .carousel_faclok .carousel__item.active {\r\n        transform: scale(1) translateX(-0%);\r\n      }\r\n      .carousel_faclok .carousel__item {\r\n        width: 100%;\r\n        transform: translateX(-0%) scale(1);\r\n        border-radius: 5px;\r\n        transition: all 0.7s ease;\r\n        display: flex;\r\n\r\n        text-transform: uppercase;\r\n        justify-content: center;\r\n\r\n        align-items: center;\r\n        height: 440px;\r\n      }\r\n@media (max-width: 700px) {\r\n  .carousel_faclok, .carousel__item{\r\n    height: 220px;\r\n  }\r\n}\r\n    </style>";

        public static string GetBody(string content)
          => string.Join(string.Empty, START_BODY, content, END_BODY);

        public static string GetBody(string[] content)
          => string.Join(string.Empty, START_BODY, string.Join(string.Empty, content), END_BODY);

        public static string GetItemImage(string url, bool isActive = false)
            => string.Format(IMG_PATTERN, isActive ? "active" : string.Empty, url);

        public static string GetStyleOnCount(int countImg)
            => string.Join(string.Empty, START_STYLE, countImg, END_STYLE);
    }
}
