# ZODOC

[New version](https://zodoc.netlify.com) (from develop branch)
Source code of [zodoc](https://tesar-tech.github.io/zodoc/docs/)

[![Build status](https://ci.appveyor.com/api/projects/status/r4w78a1eurq9ktnk?svg=true)](https://ci.appveyor.com/project/tesar-tech/zodoc)

![](input/assets/img/kytka256.jpg)

## Konvence pro přispívání

[Ukázkový příspěvek](https://tesar-tech.github.io/zodoc/docs/cs/selective_blur)

### 1. Obecné

1. Soubory nazývejte výstižnými názvy v AJ (podle stejného názvu souboru se párují jazykové mutace). Názvy souborů malými písmeny, jako oddělovač využijte podtržítko. Např.: `image_segmentation.md`
2. Používejte infinitiv namísto imperativu ("Načíst a zobrazit obrázek" vs "Načtěte a zobrazte obrázek")
3. V případě tvorby dokumentů do sekce `Exercises` jsou konvence lehce jiné. Vysvětlené jsou v ukázkovém cvičení.
4. Využívejte metadata `description`
5. (Podnadpisy jsou první úrovně (#). Hlavní nadpis je v metadatech jako `title`).(Není příliš důvod využívat podnadpisy, viz Struktura).

### 2. Struktura

Struktura by měla vypadat následovně:

- Krátký úvod k "úloze"
- Obrázek výsledku (popřípadě postupu)
- Okomentovaný zdrojový kód jak bylo výsledku dosaženo
  - Zdrojový kód by měl být v jednom (kopírovatelném) bloku.

### 3. Obrázky

1. Pro obrázky je nejlepší použít časovou značku (zmíněný doplněk pro vscode toto umí automaticky). Formát je následující: yyyy-MM-dd-HH-mm-ss, tedy například pro 4. 11. 2018 v 10 hodin 20 minut a 30 sekund:  `2018-11-04-10-20-30.jpg`. Je to z důvodu minimalizace rizik duplicit a přehlednějšího třídění ve složce.
2. Snažte se ořezávat obrázky tak, aby neměly zbytečně velký okraj.
3. Zvolte vhodné rozlišení obrázků. Spíše menší. I obrázek kytky o velikosti 256 x 256 pixlů splňuje účel zobrazení potřebné informace.
4. Obrázky ukládejte do složky /media

### 4. Zdrojový kód

1. Obsahuje-li výstup více obrázků vytvořených pomocí funkce `subplot`, následný `imshow` dejte na stejný řádek.
2. Ukázky kódu patřičně zarovnejte (v Matlabu označit vše a potom Ctrl+I)
3. Pro oddělení logických částí využívejte oddělovač buňěk z MATLABu (%%) a prázdný řádek.
