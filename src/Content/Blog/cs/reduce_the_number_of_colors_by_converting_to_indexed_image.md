title: Snížení množství barev pomocí převodu na indexový formát
lead: Načíst obrázek v RGB formátu a převést ho na indexový s nižším množstvím barev
published: 2018-11-10
Tags: [matlab,indexed image, colors]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

``` matlab
A=imread('kytka256.jpg');
[AInd,map]=rgb2ind(A,7); % 7 barev
imshow(AInd, map); %Každý řádek v mapě je jedna barva z obrázku v RGB formátu
 ```
