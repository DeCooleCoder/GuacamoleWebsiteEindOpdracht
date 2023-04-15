(function($) {
    // Deze functie is alleen verantwoordelijk voor de functie van één carrouselafbeelding telkens wanneer deze wordt aangeroepen
    // Dat wil zeggen, er wordt slechts één carrousel gegenereerd en het bereik van deze functie kan slechts aan één carrousel worden toegewezen
    // Het is vereist om het hoofdlabel van de huidige carrousel door te geven bij het aanroepen van deze functie
    // De formele parameter ele is hier het rootlabel van een carrousel
    var slide = function(ele,options) {
        var $ele = $(ele);
     // standaard instellingsopties
        var setting = {
        		// Bepaal de animatietijd van de carrousel

            speed: 1000,
        // Regel de intervaltijd (carrouselsnelheid)
            interval: 2000,
            
        };

        // object samenvoegen
        $.extend(true, setting, options);
        // Geef de positie en status van elke afbeelding op
        var states = [
            { $zIndex: 1, width: 120, height: 150, top: 69, left: 134, $opacity: 0.2 },
            { $zIndex: 2, width: 130, height: 170, top: 59, left: 0, $opacity: 0.4 },
            { $zIndex: 3, width: 170, height: 218, top: 35, left: 110, $opacity: 0.7 },
            { $zIndex: 4, width: 224, height: 288, top: 0, left: 263, $opacity: 1 },
            { $zIndex: 3, width: 170, height: 218, top: 35, left: 470, $opacity: 0.7 },
            { $zIndex: 2, width: 130, height: 170, top: 59, left: 620, $opacity: 0.4 },
            { $zIndex: 1, width: 120, height: 150, top: 69, left: 500, $opacity: 0.2 }
        ];

        var $lis = $ele.find('li');
        var timer = null;

        // evenement
        $ele.find('.hi-next').on('click', function() {
            next();
        });
        $ele.find('.hi-prev').on('click', function() {
            states.push(states.shift());
            move();
        });
        $ele.on('mouseenter', function() {
            clearInterval(timer);
            timer = null;
        }).on('mouseleave', function() {
            autoPlay();
        });

        move();
        autoPlay();

        // Laat elke li overeenkomen met elke toestand van de bovenstaande toestanden
        // Laat li uitbreiden vanuit het midden
        function move() {
            $lis.each(function(index, element) {
                var state = states[index];
                $(element).css('zIndex', state.$zIndex).finish().animate(state, setting.speed).find('img').css('opacity', state.$opacity);
            });
        }

        // ga naar de volgende
        function next() {
            // Principe: verplaats het laatste element van de array naar het eerste
            states.unshift(states.pop());
            move();
        }

        function autoPlay() {
            timer = setInterval(next, setting.interval);
        }
    }
    // Zoek het hoofdlabel van de te draaien carrousel en roep slide() aan // Zoek het hoofdlabel van de te draaien carrousel en roep slide() aan
    $.fn.hiSlide = function(options) {
        $(this).each(function(index, ele) {
            slide(ele,options);
        });

        // retourneer waarde om kettingoproepen te ondersteunen
        return this;
    }
})(jQuery);
