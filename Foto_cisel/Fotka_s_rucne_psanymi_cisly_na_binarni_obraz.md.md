
title: # Fotka s ručně psanými čísly na binární obraz
---
>Budete potřebovat: 
 
* [Obrázek čísla](/zodoc/media/cisla_ver.jpg) v proměnné `Image` 

# Úkol
Převést obrazek do binární reprezentace, kde bílé budou jednotlivé čísla a černé pozadí.
# Načíst obrazek
Image= imread('cisla_ver.jpg');
imshow(Image)
![](../media/2018-11-14-22-32-00.jpg)
# Prevezt obrazek do binarni 

 BW = im2bw(B,0.5); 
![](../media/2018-11-14-22-32-32.jpg)
 
# Eroze Binarni obraz
 se = strel('line',10,90);
 erodedBW = imerode(BW, se);
 imshow(erodedBW),
  Vytvoření strukturovaného prvku . A použti funkce imerode, která rozložení objektu na jednodušší časti
![](E:\zodoc\2018-11-14-22-33-15.jpg)
# Bilé čísla a černé pozadí
bw2 = imcomplement(BW);
imshow(bw2)
![](../media/2018-11-14-22-33-25.jpg)

