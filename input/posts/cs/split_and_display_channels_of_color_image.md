title: Jednotlivé barevné kanály
lead: Rozdělení a zobrazení barevných kanálů obrázku
Published: 2019-01-03
Tags: [matlab, RGB, channels]
datazooFiles: imgs/kytka256.jpg
prerequisites: [Matlab]
Authors: [tesar-tech, Karina9510]
---
Script zobrazuje jednotlivé barevné kanály na RGB obrázku.
Ve případě zobrazení vybraného barevného kanálu na původním obrázku se objevují šedé pixely. Tohle to se projevuje v tom případě, když už do existující barevného kanálu se přidává jiný barevný kanál. Tyto oblasti odpovídají hodnotám pixelů, které neobsahují žádné hodnoty přidaného RGB kanálů.

Pokud sloučením dvou barevných kanálů na obrázku se objevuji bílé oblasti, to znamená že se sčítají sejné barevné kanály nebo barva původního obrázku už obsahuje přidávající se kanál. Vysvětlením tohoto jevu je to, že každá samostatná barevná rovina na obrázku obsahuje bílou oblast, která odpovídá nejvyšším hodnotám (nejčistším odstínům) jednotlivé barvy.

``` matlab
A = imread('kytka256.jpg');
R=insertText(A(:,:,1),[1 1],'cerveny','FontSize',22);
G=insertText(A(:,:,2),[1 1],'zeleny','FontSize',22);
B=insertText(A(:,:,3),[1 1],'modry','FontSize',22);
montage({insertText(A,[1 1],'puvodni','FontSize',22), R, G, B});
```
![](../media/2019-01-04-10-43-16.jpg)

