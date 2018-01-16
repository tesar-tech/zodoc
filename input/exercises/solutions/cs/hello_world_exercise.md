title: Zkušební cvičení
order: 0

---
# Úvod
Toto je řešení, většinou zdrojový kód.
``` matlab
clc;
clear all; 
%% komentář v matlabu
A = zeros(100);% tvorba čtvercové matice (binární obraz)
A(50:70, 70:90) = 1; % umístění bílého čtverce
A = imrotate(A,42)% rotace obrázku o 42 °
imshow(A); % vykreslení obrázku
```


