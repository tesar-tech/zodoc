title: Filtrování binárních objektů za použití k-means
lead: Binarizuje obrázek, zaplní díry, očistí okraje a oddělí nechtěné malé objekty za pomoci k-means algoritmu
Published: 2018-11-16
Tags: [matlab, binary image, shapes, kmeans]
datazooFiles:  imgs/tvary.png
prerequisites: Matlab
Authors: tesar-tech
---

Úkolem je zpracovat obrázek do binární reprezentace tak, aby obsahoval pouze žádoucí tvary jako je obdélník, čtverec, trojúhelník kruh nebo hvězda. K-means algoritmus slouží k určení meze pro filtrování objektů dle jejich velikostí.

``` matlab
A = imread('tvary.png');
Aa = {};
Aa{1} =A; %barevný obrázek
Ag =imadjust(rgb2gray(A));% upraví kontrast a převede na šedotón
Aa{2} = Ag;
Aa{3} = imbinarize(Ag,'adaptive','ForegroundPolarity','dark','Sensitivity',0.55); %na černobílý obrázek
Aa{4} = imfill(~Aa{end},'holes'); %zaplní díry
Aa{5} = imclearborder(Aa{end}); % vyčístí objekty z hran 
%% filtrace za použití k-means
reg_props = regionprops(Aa{5},'area');%získání velikostí ploch (area) každého objektu
areas =  [reg_props.Area]';% převede plochy na vektor
%hist(areas,30) % zobrazí histogram velikostí ploch
[indx, ~] = kmeans(areas,3);% oddělí objekty do 3 shluků na základě jejich velikostí.
%jeden shluk zahrnuje větší objekty, druhý shluk menší objekty a "šumovité" objekty (které chceme odstranit)
% jsou v jednom vlastím shluku.
% (nefunguje to příliš dobře pouze pro 2 shluky)

%Nevím předem který ze shluků obsahuje ty nejmenší objekty.
%Vezme největší objekty z každého shluku. Minimum těchto tří objektů
%je vzato jako limit pro filtrování ()
min_max = min([max(areas(indx==1)),max(areas(indx==2)),max(areas(indx==3)) ]);
Aa{6} = bwareafilt(Aa{5},[min_max+1 Inf]);
%%
montage(Aa,'bordersize',[1 1],'backgroundcolor','green')
```