title: Histogramové operace s obrázky
Description: Vykreslení histogramu, ekvalizace a deekvalizace pomocí histogramu. Vytvoření nástroje pro interaktivní zvýraznění části RTG snímku zubů.
---
>Tento dokument pracuje se třemi obrázky:

* [Obrázek kytky](../media/kytka256.jpg) v proměnné `A` 
* Vestavěný obrázek *pout.tif* v proměnné `B`
* [RTG snímek zubů](../media/zubRtg.png) v proměnné `C`
# Vykreslení histogramu

```matlab
A=imread('kytka256.jpg'); % načtení obrázku 
Ag = rgb2gray(A);
subplot(1,2,1);imshow(Ag) % původní obrázek
subplot(1,2,2);imhist(Ag) % vykreslení histogramu
```
![](../media/2017-12-18-14-54-00.png)
# Histogram a ekvalizovaný histogram
``` matlab
B=imread('pout.tif'); %pout.tif je vestavěný obr. v Matlabu

subplot(2,2,1);imshow(B)
subplot(2,2,2);imhist(B)

subplot(2,2,3);imshow(histeq(B)) % ekvalizace obrázku
subplot(2,2,4);imhist(histeq(B)) % vykreslení ekvalizovaného histogramu 
```
# "Deekvalizace" obrázku - snížení kontrastu
``` matlab
subplot(2,2,1);imshow(Ag)
subplot(2,2,2);imhist(Ag)

Dq=(Ag*0.2)+100; % deekvalizace obrázku pomocí násobení a sčítání
subplot(2,2,3);imshow(Dq)
subplot(2,2,4);imhist(Dq) 
```
![](../media/2017-12-18-14-57-53.png)
# Interaktivní zvýraznění části RTG snímku zubů
Uživatel bude moci kliknutím vybrat oblast snímku k ekvalizaci

``` matlab
C=imread('zubRtg.png');
button=1; % tlačítko
x=300;y=300; % velikost oblasti v pixelech - menší = lepší vykreslení
figure;
ax = axes; % uložení os do proměnné

while button==1 % kliknutí levým tlačítkem na tlačítko
    if x>100 && y >100 % vynechání okrajů snímku
        z_ekv=C;
        z_ekv(x-100:x+100,y-100:y+100)=histeq(z_ekv(x-100:x+100,y-100:y+100));
        imshow(z_ekv,'Parent',ax)
    end
    
    [y,x, button]=ginput(1); % čekání na zmáčknutí tlačítka
end
```
## Adaptivní ekvalizace
Adaptivní ekvalizace se liší od obyčejné tím, že počítá histogramy jednotlivých částí obrázku. Tím je dosaženo vyššího lokálního kontrastu v celém obrázku.
``` matlab
subplot(2,1,1), imshow(C)
% parametr [m n] udává počet 'dlaždic', do kterých je obrázek rozdělen při zpracování
z_ekvadaptive=adapthisteq(C,'NumTiles',[100 100]); 
subplot(2,1,2), imshow(z_ekvadaptive) 
```
![](../media/hist5_zubr_adeq.png)