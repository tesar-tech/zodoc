title: Transfer Learning 
lead: Transfer Learning příklad použití na nouronové síti Alexnet.
Published: 2019-01-09
Tags: [matlab, imageset, shapes, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, magias]
---
# Transfer Learning
Transfer learning je běžně používaná metoda deep learningovými aplikacemi. V praxi to znamená, že lze použít vytrénovanou neuronovou síť, jako výchozí bod pro učení sítě nové. Použití vlastností ideálně přednastavené sítě je většinou mnohem jednodušší a rychlejší, než nevyzkoušené nastavení neuronové sítě. Další výhodou je možnost rychlého přepojení naučené funkce pro nové úkoly neuronové sítě a to za použití menšího počtu obrázků pro její vytrénování.

## Načtení Datasetu
Pro následnou ukázku načteme obrazový dataset, který obsahuje 3 labely: circle, rectangle a triangle, vytvořený tímto [skriptem](https://zodoc.netlify.com/posts/en/creating_an_image_set_with_various_shapes)

``` matlab
imds = imageDatastore('imgs_shapes', ... %načtení obrázků ze složky
    'IncludeSubfolders',true, ... %načtení podsložek
    'LabelSource','foldernames'); %použití označení podle názvu souborů 
```
Rozdělíme jednotlivé labely na na trénovací a validační v poměru 7/3.
``` matlab
%rozdělí dataset podle labelu na dva datasety trenovací a validační
[imdsTrain,imdsValidation] = splitEachLabel(imds,0.7,'randomized');
```
Tento dataset obsahuje pouze 21 obrázků pro trénování a 7 validačních obrázků. Zde je kód pro zobrazení náhodného vzorku obrázků.
``` matlab
%náhodné načtení a zobrazení vzorku obrázků
numTrainImages = numel(imdsTrain.Labels);
idx = randperm(numTrainImages,16);
figure
for i = 1:16
    subplot(4,4,i)
    I = readimage(imdsTrain,idx(i));
    imshow(I)
end
```
## Načtení Předtrénované Neuronové Sítě
```matlab
net = alexnet;
analyzeNetwork(net); % zobrazí okno s jednotlivými vrstvami 
```
## Výměna posledních vrstev
Poslední tři vrstvy předem připravené neuronové sítě `net` jsou konfigurovány pro 1000 labelů. Tyto poslední tři vrstvy upravíme pro naší neuronovou síť. Vyextrahujeme si všechny vrstvy, s výjimkou posledních tří, z předem připravené sítě.
```matlab
inputSize = net.Layers(1).InputSize; % velikost vstupu
layersTransfer = net.Layers(1:end-3);
numClasses = numel(categories(imdsTrain.Labels)); % počet labelů
```
Přesuneme vrstvy pro novou klasifikační úlohu tak, že nahradíme poslední tři vrstvy `fully connected layer`, `softmax layer` a `classification output layer`.Určíme možnosti nové `fully connected layer` odpovídající novému datasetu. Nastavíme `fully connected layer` na stejnou velikost jako počet labelů v našem datasetu.
```matlab
layers = [
    layersTransfer
    fullyConnectedLayer(numClasses,'WeightLearnRateFactor',20,'BiasLearnRateFactor',20)
    softmaxLayer
    classificationLayer];
```
## Trénování Neuronové Sítě
Trénovaná síť vyžaduje vstup obrázků o velikosti 227x227 pixelů. Augmentace dat pomáhá zabránit přeplnění sítě a zapamatování přesných detailů trénovaných obrázků. Náhodně převrátí trénované obrázky podél svislé osy a náhodně je překládá až 30 pixelů vodorovně a svisle.Podobně upravíme i validační obrázky.
```matlab
pixelRange = [-30 30];
imageAugmenter = imageDataAugmenter( ...
    'RandXReflection',true, ...
    'RandXTranslation',pixelRange, ...
    'RandYTranslation',pixelRange);
augimdsTrain = augmentedImageDatastore(inputSize,imdsTrain, ... % treningový dataset
    'DataAugmentation',imageAugmenter);

    augimdsValidation = augmentedImageDatastore(inputSize,imdsValidation); % validační dataset
```
Zadáme nastavení pro tréning neuronové sítě
```matlab
options = trainingOptions('sgdm', ...
    'MiniBatchSize',10, ...
    'MaxEpochs',12, ... 
    'InitialLearnRate',1e-4, ...
    'Shuffle','every-epoch', ...
    'ValidationData',augimdsValidation, ...
    'ValidationFrequency',3, ...
    'Verbose',false, ...
    'Plots','training-progress');
```
Začneme trénovat síť, která se skládá z přenesených a upravených vrstev.
```matlab
netTransfer = trainNetwork(augimdsTrain,layers,options);
```
## Validace Sítě
Validační obrázky klasifikujeme pomocí naší upravené sítě. A zobrazíme si jejich náhodný vzorek.
```matlab
[YPred,scores] = classify(netTransfer,augimdsValidation);
idx = randperm(numel(imdsValidation.Files),4);
figure
for i = 1:4
    subplot(2,2,i)
    I = readimage(imdsValidation,idx(i));
    imshow(I)
    label = YPred(idx(i));
    title(string(label));
end
```
Následně můžeme vypočítat přesnost námi vytrénované neuronové sítě.
```matlab
YValidation = imdsValidation.Labels;
accuracy = mean(YPred == YValidation)
```
