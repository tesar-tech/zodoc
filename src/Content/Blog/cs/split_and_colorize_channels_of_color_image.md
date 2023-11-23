title: Rozdělit a obarvit kanály barevného obrazu
lead: Zobrazit RGB kanály z barevného obrazu jako tři různé RGB obrázky
Published: 2018-11-13
Tags:  [matlab, RGB, colors]
prerequisites: [Matlab]
Authors: tesar-tech
---

Tento příspěvek je vylepšením [předchozího](split_and_display_channels_of_color_image). Kanály jsou obarveny vynulováním ostatních.

```matlab
A = imread('kytka256.jpg');
R1=A;G1=A;B1=A; %vytvořit kopii původního RGB obrázku

R1(:,:,[2,3])=0;
G1(:,:,[1,3])=0;
B1(:,:,[1,2])=0;

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R1);title('Red');
subplot 223;imshow(G1);title('Green');
subplot 224;imshow(B1);title('Blue');
```
