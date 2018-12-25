
title: # Generování náhodných hvězdiček
---
# Úkol
 Snažíme vytvořit hvězdičky různých velikostí a rotací. Hvězdička bude pravidelná, pěticípá.
# Určete proměnné polygonu
numVert = 5;
radius = 1;
x = zeros(numVert,1);
y = zeros(numVert,1);
 
# úhel kružnice jednotky v radiánech
 circleAng = 2*pi;

# průměrná úhlová vzdálenost mezi body v jednotkovém kruhu
angleSeparation = circleAng/numVert;
# vytvořit matici úhlů pro rovnoměrné oddělení bodů
angleMatrix = 0: angleSeparation: circleAng;
# pokles konečného úhlu od 2Pi = 0
angleMatrix(end) = [];
# generujte body x a y
for k = 1:numVert
    x(k) = radius * cos(angleMatrix(k));
    y(k) = radius * sin(angleMatrix(k));
end
# Nakreslete polygon a konečný bod připojte k prvnímu bodu
plot([x; x(1)],[y; y(1)],'ro-')
hold on
plot([-2 2],[0 0],'k')
plot([0 0],[-2 2],'k')
