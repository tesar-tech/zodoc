title: Oddělení kulatých objektů od objektů ostatních
Description: From black&white image with different objects, select only round ones (circles). Z černobílého obrázku s různými tvary budou vybrány pouze ty "kulaté" (kruhy).
---

>Tento příspevěk je pokračováním příspěvku [předchozího](filtering_binary_objects_with_kmeans), který se zabýval zpracováním obrázku s tvary.

![](../media/2018-11-18-10-20-30.png)

``` matlab
reg_props2 = regionprops(Aa{6},'perimeter','EquivDiameter','area');

[~,L] = bwboundaries(Aa{6},'noholes');% označení objektů čísly  1:num_of_regions

%Kruhy v tomto obrázku nejsou zcela kulaté. Hledáme "skoro" kulaté objekty
%EquivDiameter je průměr kruhu, jenž by zabíral stejnou plochu jako daný objekt
%Area/Perimeter + maláKonstanta > EquivDiameter/4   pro kruhové objekty
%kulaté objekty (kruhy) mají nejvyšší poměr plochy/obvodu ze všech možných tvarů
% Area/Perimeter = Diameter/4 - platí pro kruh 
where_is_true =([reg_props2.Area] ./ [reg_props2.Perimeter]+1) > [reg_props2.EquivDiameter]/4;
 
Aa{7} =  ismember(L, find(where_is_true));%filtrace nekulatých objektů z obrázku

montage({Aa{6},Aa{7}},'bordersize',[1 1],'backgroundcolor','green')
```