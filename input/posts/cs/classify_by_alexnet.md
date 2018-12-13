title: Klasifikace obrázků s pomocí alexnet
lead: Konvoluční neuronová síť alexnet je použita ke klasifikaci obrázku
Published: 2018-11-15
Tags: [matlab, alexnet, classification]
datazooFiles: imgs/kytka256.jpg
prerequisites: [Matlab, Alexnet matlab add-on]
Authors: tesar-tech
---

Testovaný obrázek je klasifikován jako sedmikráska (daisy), což není správně, jelikož žlutý květ na obrázku náleží topinambuře. Nicméně topinambura není jednou z tříd do které alexnet klasifikuje (je jich celkem 1000) a sedmikrásce je vcelku podobná, takže klasifikace není zcela špatná. Pět klasifikací s nejvyšším skóre je vyobrazeno v tabulce.

```matlab
net = alexnet;
A = imread('kytka256.jpg');
A_resized = imresize(A,[227 227]); %změnit velikost na 227px 227px pro vstup cnn
[label,score] = classify(net,A_resized); % klasifikace obrázku

[maxvalues, ind] = maxk(score(:), 5); %zíkání 5 klasifikací s nejvyšším skóre

subplot 121; imshow(A_resized); %zobrazit původní obrázek
title(string(label) + ", " + num2str(max(score)*100,3) + " %"); % zobrazit klasifikaci a procenta

names=(net.Layers(end).ClassNames(ind)); % získání jmen pro klasifikace
uitable('Data',[names,num2cell(maxvalues*100)],'Position',[290 150 150 130],'ColumnName',{'Class name','Score %'});% vytvoření tabulky
```