title: Transfer Learning s použitím AlexNet
lead: Příklad použití transfer learningu na neuronové síti Alexnet s databázi vygenerovaných tvarů.
Published: 2019-01-09
Tags: [matlab, imageset, shapes, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, magias]
---

Transfer learning je běžně používaná metoda deep learningovými aplikacemi. V praxi to znamená, že lze použít vytrénovanou neuronovou síť, jako výchozí bod pro učení sítě nové. Použití vlastností ideálně přednastavené sítě je většinou mnohem jednodušší a rychlejší, než nevyzkoušené nastavení neuronové sítě. Další výhodou je možnost rychlého přepojení naučené funkce pro nové úkoly neuronové sítě a to za použití menšího počtu obrázků pro její vytrénování. Pro následnou ukázku načteme obrazový dataset, který obsahuje 4 labely: circle, rectangle , triangle a star vytvořený tímto [skriptem na tvary](creating_an_image_set_with_various_shapes) a tímto [skriptem na hvezdy](creating_an_imageset_of_random_stars).

``` matlab
imds = imageDatastore('imgs_shapes', ... %načtení obrázků ze složky
    'IncludeSubfolders',true, ... %načtení podsložek
    'LabelSource','foldernames'); %použití označení podle názvu souborů 

%rozdělí dataset podle labelu na dva datasety trenovací a validační
[imdsTrain,imdsValidation] = splitEachLabel(imds,0.7,'randomized');

%náhodné načtení a zobrazení vzorku obrázků
numTrainImages = numel(imdsTrain.Labels);
idx = randperm(numTrainImages,16);
figure
for i = 1:16
    subplot(4,4,i)
    I = readimage(imdsTrain,idx(i));
    imshow(I)
end

% Načtení Předtrénované Neuronové Sítě
net = alexnet;

% Výměna posledních tří vrstev 
inputSize = net.Layers(1).InputSize; % velikost vstupu
layersTransfer = net.Layers(1:end-3);
numClasses = numel(categories(imdsTrain.Labels)); % počet labelů

%Přesuneme vrstvy pro novou klasifikační úlohu tak
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