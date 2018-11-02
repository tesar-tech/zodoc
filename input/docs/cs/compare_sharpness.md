title: Porovnání ostrosti dvou obrazů
--- 
# Rozmazání obrázku, hledání hran
 ``` matlab
A=imread('kytka256.jpg');
% vytvoření gausovského filtru, 12 je velikost filtru, 10 je sigma neboli směrodatná odchylka
f=fspecial('gaussian',12,10);
A_rozmazana=imfilter(A,f); % aplikace vytvořeného filtru na obrázek

A_rozm_seda=rgb2gray(A_rozmazana);
A_seda=rgb2gray(A);
% funkce edge hledá hrany na obrázku, vrací binární obraz
A_rozm_E=edge(A_rozm_seda);
A_seda_E=edge(A_seda);

 ```
# Porovnání ostrosti podle hran
Základní předpoklad je, že u ostřejšího obrazu najde funkce edge více hran
 ``` matlab
 % matice vrácená funkcí edge je binární (obsahuje jen 0 a 1). 1 reprezentuje hranu. 
 % stačí porovnat, ve které matici je více jedniček.
C=find(A_seda_E==1); 
B=find(A_rozm_E==1);
if (length(C)>length(B))
    disp('Ostřejší je původní obrázek');
elseif (length(C)<length(B))
    disp('Ostřejší je filrovaný obrázek');
else
   disp('není možné určit, který obrázek je ostřejší'); %např.obrázky mají stejný počet hran  
end 
 ```
# Vykreslení výsledku
 ``` matlab
subplot (2,2,1); imshow(A); title('původní');
subplot (2,2,2); imshow(A_rozmazana);  title('filtrovaný');
subplot (2,2,3); imshow(A_seda_E);
subplot (2,2,4); imshow(A_rozm_E);  
 ```
 
 ![](../media/compare_sharpness_result.jpg)
