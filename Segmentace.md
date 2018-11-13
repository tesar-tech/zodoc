title: Segmentace tvarů s pomocí k-means

# K-means
K - means je často používaný algoritmus nehierarchické shlukové analýzy. Předpokládá, že shlukované objekty lze chápat jako body v nějakém eukleidovském prostoru a že počet shluků k je předem dán. Shluky jsou definovány svými centroidy, což jsou body ve stejném prostoru jako shlukované objekty. Objekty se zařazují do toho shluku, jehož centroidu jsou nejblíže. Algoritmus postupuje iterativně tak, že se vyjde z nějakých centroidů, přiřadí do nich body, přepočítá centroidy tak, aby šlo těžiště shluku bodů, pak opět přiřadí body k nově stanoveným centroidům a tak dál, až dokud se poloha centroidů neustálí.

# Načtení obrázku, převedení na šedotónový
```matlab
Obr = imread('tvary.png');
Obrazek = {};
Obrazek{1} =Obr;% přiřazení první pozice původnímu obrázku
Ag =imadjust( rgb2gray(Obr)); % určení kontrastních limitů pomocí funkce imadjust ve vstupním šedotónovém obrázku
Obrazek{2} =Ag;% přiřazení druhé pozice šedotónovému obrázku
```
# Binarizace obrázku
```matlab
Obrazek{3} = imbinarize(Ag,'adaptive','ForegroundPolarity','dark','Sensitivity',0.55);
% binarizcace šedotóvého 2-D obrazu, adaptivní prahování, popředí bude tmavší, než pozadí a citlivostí z rozsahu [0,1]
Obrazek{4} = imfill(~Obrazek{end},'holes'); % vyplnění děr v binarizovaném obrázku
Obrazek{5} = imclearborder(Obrazek{end}); % odstranění objektů, co se dotýkají hrany
```
# Odfiltrování nechtěných objektů
```matlab
Obrazek{6} = bwareafilt(Obrazek{end},[1000 Inf]); % extrahuje objekty z binárního obrazu podle velikosti
```
# K means 
```matlab
reg_props = regionprops(Obrazek{5},'area');% změří vlastnosti objektů obrázku
areas =  cat(1,reg_props.Area);
hist(areas,30)
[indx, Centers] = kmeans(areas,3);
min_max = min([max(areas(indx==1)),max(areas(indx==2)),max(areas(indx==3)) ]);
Obrazek{6} = bwareafilt(Obrazek{5},[min_max Inf]);
```
# Vykreslení obrázku
```matlab
montage(Obrazek,'bordersize',[1 1],'backgroundcolor','green') 
% název souboru, ohraničení obrazu barvou pozadí, určení rozložení obrázků, vyplnění všech mezer barvou pozadí, zadaná barva pozadí
```

