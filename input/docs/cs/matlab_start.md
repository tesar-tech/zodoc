title: Základní operace s obrázky
Description: První kapitola základních operací s obrázky
---
>Tento dokument pracuje s [obrázkem](/zodoc/assets/img/kytka256.jpg) uloženém v proměnné`A`.
# Načíst a zobrazit obrázek
```matlab
A=imread('kytka256.jpg');
imshow(A)
```
![](/zodoc/assets/img/kytka256.jpg)

Obrázek musí být ve složce, ve které současně pracujete s matlabem. 
# Převést RGB obrázek do šedotónu
```matlab
Ag = rgb2gray(A);
imshow(Ag)
```
![](../media/2017-12-04-17-47-57.png)

# Zobrazit jednotlivé barevné kanály
``` matlab
R=A(:,:,1);
G=A(:,:,2);
B=A(:,:,3);

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R);title('Cerveny kanal');
subplot 223;imshow(G);title('Zeleny kanal');
subplot 224;imshow(B);title('Modry kanal');
```
Všimněte si tmavé barvy v modrém kanálu, která není součástí žluté barvy, narozdíl od červeného a zeleného kanálu.

![](../media/2017-12-04-17-59-08.png)
## Zbarvení kanálů

Nastavte nebarevné kanály na nulu.

``` matlab
R1=A;G1=A;B1=A; %nakopírujte originální obrázek do nových proměnných

%nastavte nulové hodnoty ostatních barev, pro zobrazení vždy jen jednoho kanálu
R1(:,:,[2,3])=0; 
G1(:,:,[1,3])=0;
B1(:,:,[1,2])=0;

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R1);title('Cerveny kanal');
subplot 223;imshow(G1);title('Zeleny kanal');
subplot 224;imshow(B1);title('Modry kanal');
```

![](../media/colorizedChannels.png)

# Negativ obrázku

```matlab
An=imcomplement(A);
%nebo
An= 255-A;%pokud je obrázek typu uint8
imshow(An)
```

![](../media/negative.png)

# Černobílá

``` matlab
Abw = imbinarize(Ag);%proměnná ze šedotónu
%BW = im2bw(A);% používá se ve starších verzích matlabu
imshow(Abw)

```
![](../media/binarized.png)

## Jiný způsob černobílé
Výsledek `Ag<128` je binární matice - tzn. černobílý obrázek
``` matlab 
imshow(Ag<128);
```
# Animovaný černobílý obrázek
``` matlab
figure
ax = axes;% abyste přepsali původní figuru
THR=0;
for i=1:100
    while (THR<=255)
        imshow(Ag>THR,'Parent',ax)
        THR=THR+10;
        pause(0.05)
    end
    while (THR>=0)
        imshow(Ag>THR,'Parent',ax)
        THR=THR-10;
        pause(0.05)
    end
end
```
## Uložit animaci jako gif
``` matlab
firstTime = 1;gifName = 'bw_anim.gif';
for ii = 1:5:256
    
   curr_img = (Ag<ii)*255;% hodnoty 0 a 255 
   [A,map] = gray2ind(curr_img,2); 
   
    if firstTime ==1%první snímek je uložen zvlášť
        imwrite(A,map,gifName,'gif','LoopCount',Inf,'DelayTime',0.001);
    firstTime = 0;
    else
        imwrite(A,map,gifName,'gif','WriteMode','append','DelayTime',0.001);
    end 
 end
 %pak zkontrolovat složku ve které pracujete, zda je gif uložen
```
![](../media/bw_anim.gif)

## Indexové zobrazení
Indexové zobrazení se používá kvůli snížení velikosti (té, která zabíra místo na disku, nikoliv samotného rozlišení) obrázku a zbytečnému použití výpočetní paměti.

``` matlab
[AInd,map]=rgb2ind(A,7);
imshow(AInd, map); %přes mapování, každý řádek v "map" představuje jednu
%barvu (RGB)
%Pixel v indexovém obraze je indexem do mapy barev.
%Hodnota 7 je variabilní a představuje, kolika barevný bude výsledný obraz.

```
![](../media/kytka_index.jpg)
