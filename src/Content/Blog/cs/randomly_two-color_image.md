title: Náhodně dvoubarevný obrázek
lead: Z RGB obrázku vytvořit náhodně dvoubarevný
Published: 2018-11-12
Tags: [matlab, binary image, RGB,random]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

Převede obrázek na binární reprezentaci a obarví náhodnými barvami. Je zajištěno, že barvy ani hodnoty v jednotlivých kanálech nebudou stejné.

``` matlab
A=imread('kytka256.jpg');
Ag = rgb2gray(A);% převod na šedotón
colors = randperm(256,6) -1;% šest náhodných čísle od 0 do 255
Ab = imbinarize(Ag);%převod na binární obraz
Ab_3D = repmat(Ab,[1 1 3]);%replikování binárního obrazu do 3 rozměrů
R = Ab*colors(1) + ~Ab*colors(2);% 1 * barva = barva
G = Ab*colors(3) + ~Ab*colors(4);
B = Ab*colors(5) + ~Ab*colors(6);
Ab_RGB = cat(3,R,G,B);%spojení ve 3. rozměru

imshow(uint8(Ab_RGB));
```