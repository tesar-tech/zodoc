title: Rozdělit a zobrazit kanály barevného obrazu
lead: Zobrazit RGB kanály z barevného obrazu jako tři různé šedotónové obrázky
Published: 2018-11-12
Tags:  [matlab, RGB, colors]
prerequisites: [Matlab]
Authors: tesar-tech
---

RGB obraz je složen ze tří barevných kanálů. Tento skript kanály rozdělí do separátních proměnných a zobrazí je jako šedotónové obrázky.

```matlab
A = imread('kytka256.jpg');
R=A(:,:,1);
G=A(:,:,2);
B=A(:,:,3);

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R);title('Red');
subplot 223;imshow(G);title('Green');
subplot 224;imshow(B);title('Blue');
```
