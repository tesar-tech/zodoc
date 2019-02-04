title: Transfer Learning s použitím AlexNet
lead: Použití transfer learningu na neuronové síti Alexnet s databází vygenerovaných tvarů
Published: 2019-01-09
Tags: [matlab,alexnet, imageset, shapes, transfer learning]
prerequisites: [Matlab, Alexnet matlab add-on]
Authors: [tesar-tech, magias]
---

Transfer learning je běžně používaná metoda deep learningovými aplikacemi. V praxi to znamená, že lze použít vytrénovanou neuronovou síť, jako výchozí bod pro učení sítě nové. Použití vlastností předtrénované sítě je většinou mnohem jednodušší a rychlejší, než učení sítě od začátku. Další výhodou je velikost databáze, která pro transfer learning nemusí být zdaleka tak veliká. Pro tuto ukázku načteme obrazový dataset, který obsahuje čtyři třídy: kruh, obdélník, trojúhelník a hvězda vytvořený tímto [skriptem](creating_an_image_set_with_various_shapes).

``` matlab
imds = imageDatastore('imgs_shapes', ... %načtení obrázků ze složky
    'IncludeSubfolders',true, ... %načtení podsložek
    'LabelSource','foldernames'); %použití označení podle názvu souborů 

%rozdělí dataset podle labelu na dva datasety trenovací a validační
[imdsTrain,imdsValidation] = splitEachLabel(imds,0.7,'randomized');

% Načtení Předtrénované Neuronové Sítě
net = alexnet;

% Výměna posledních tří vrstev 
inputSize = net.Layers(1).InputSize; % velikost vstupu
layersTransfer = net.Layers(1:end-3);
numClasses = numel(categories(imdsTrain.Labels)); % počet labelů

%Přesuneme vrstvy pro novou klasifikační úlohu 
layers = [
    layersTransfer
    fullyConnectedLayer(numClasses,'WeightLearnRateFactor',20,'BiasLearnRateFactor',20)
    softmaxLayer
    classificationLayer];

% Trénování Neuronové Sítě
%Zadáme nastavení pro tréning neuronové sítě
options = trainingOptions('sgdm', ...
    'MiniBatchSize',10, ...
    'MaxEpochs',12, ... 
    'InitialLearnRate',1e-4, ...
    'Shuffle','every-epoch', ...
    'ValidationData',imdsValidation, ...
    'ValidationFrequency',3, ...
    'Verbose',false, ...
    'Plots','training-progress');

%Začneme trénovat síť, která se skládá z přenesených a upravených vrstev.
netTransfer = trainNetwork(imdsTrain,layers,options);
```