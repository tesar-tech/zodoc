title: Negativ z barevného obrázku
lead: Převedení barevného obrázku na jeho negativ a následné zobrazní obou těchto obrázků.
Published: 2019-01-05
Tags: [matlab, negative]
datazooFiles: imgs/kytka256.jpg
prerequisites: [Matlab]
Authors: [tesar-tech, medkolin]
---
Script zobrazuje převedění barevného obrázku na jeho negativ. A to ve variantě s využitím funkce imcomplement, která vytvoří doplňkový obrázek k původnímu barevnému obrázku a nebo s využitím odečtení hodnoty původního obrázku od maxima datového typu uint8.

``` matlab

Obrazek = imread('kytka256.jpg');

Obrazek_negativ = imcomplement(Obrazek);
%nebo
Obrazek_negativ = 255-Obrazek; %pokud je obrázek typu uint8, který má rozsah 0 až 2^8-1 tj. 255

imshowpair(Obrazek, Obrazek_negativ, 'montage')

```
![](../media/2019-01-05-09-35-09.jpg)
