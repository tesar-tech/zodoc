title: Segmentace obrázku v barevném modelu HSV
Description: Jak izolovat část obrázku podle rozsahu barev
---
>Tento dokument pracuje s [obrázkem kytky](../media/kytka256.jpg) v proměnné `A`

Segmentace části obrázku v barevném modelu HSV, který popisuje barvy třemi parametry (odstín, sytost a jas). Prahy odstínu určují rozsah barev, který izolujeme. Pro segmentaci podle barev je vhodné použít model HSV, jelikož lépe rozlišuje mezi jednotlivými barvami.

![](../media/2018-11-28-16-41-35.png)

``` matlab
% Načtení výchozího obrázku
A = imread('kytka256.jpg');
% Převod hodnot RGB do HSV
imgHSV = rgb2hsv(A);
% Nastevní prahů odstínu v rozmezí 0 až 1
hueMin = 0.000; % 0 odpovídá červené
hueMax = 0.280; % 0.28 zhruba odpovídá žluté
% Vytvoření masky z prahů (odstín je v prvním kanálu)
hueMask = (imgHSV(:,:,1) >= hueMin ) & (imgHSV(:,:,1) <= hueMax);
% Použití masky na původní obrázek k odbarvení pozadí
% (Hadamardův součin kanálu sytosti původního obrázku a masky)
imgHSV(:,:,2) = imgHSV(:,:,2) .* hueMask;
% Převod výsledného obrázku zpět do modelu RGB
imgResult = hsv2rgb(imgHSV);
imshow(imgResult);
```