title: Selektivní rozmazání
lead: Jak rozmazat pouze pozadí obrázku
Published: 11/03/2018
Tags:
  - filters
  - gaussian
  - blur
datazooFiles:
  - imgs/kytka256.jpg
---
  
Rozostřit pouze tu část, která není samotnou kytkou. Ve skutečnosti se rozostří celý obrázek a nerozmazaná místa se nahradí původním obrázkem.

``` matlab
Abin = uint8(rgb2gray(A)>128);% prahování obrazu

f_gaussian = fspecial('gaussian',20,4); % konstrukce gaussovského filtru
A_gaussian = imfilter(A,f_gaussian,'same');% uplatnění filtru. 'same' -> stejná velikost i po filtraci
Abin_rgb = repmat(Abin,[1 1 3]);%nareplikování binárního obrazu do 3 rozměrů (aby se tím dal násobit RGB obraz)
A_selective_blur = Abin_rgb.*A + (1-Abin_rgb).*A_gaussian; %nerozmazaná část + rozmazaná část

imshow(A_selective_blur)
```
