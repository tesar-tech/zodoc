
title: # Fotka s ručně psanými čísly na binární obraz
---
>Budete potřebovat: 
 
* [Obrázek čísla](../media/Image) v proměnné `Image` 

# Úkol
Převést obrazek do binární reprezentace, kde bílé budou jednotlivé čísla a černé pozadí.
# Načíst obrazek
Image= imread('cisla_ver.jpg');
imshow(Image)
![](../media/Image.jpg)
# Prevezt obrazek do binarni 

 BW = im2bw(B,0.5); 
![](../media/BW.jpg)
 
# Eroze Binarni obraz
 se = strel('line',10,90);
 erodedBW = imerode(BW, se);
 imshow(erodedBW),
  Vytvoření strukturovaného prvku . A použti funkce imerode, která rozložení objektu na jednodušší časti
![](../media/erodedBW.jpg)
# Bilé čísla a černé pozadí
bw2 = imcomplement(BW);
imshow(bw2)
![](../media/bw2.jpg)

