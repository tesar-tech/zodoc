Title: ZODOC
---
>Vznikající dokumentace k předmětu [BIZOD](https://predmety.fbmi.cvut.cz/cs/17pbizod)

> Pro otevření dokumentace přejděte na záložku [Docs](docs)

> Pro otevření proběhnuvších testů přejděte na záložku [Exercises](exercises)

# Účel
Během výuky Zpracování obrazových dat (ZOD) především pro obor Biomedicínská informatika na [fbmi.cvut.cz](https://fbmi.cvut.cz) vzniká spoustu kódu, který je dobré archivovat a udržovat a to včetně vysvětlujících poznámek a výstupu většinou ve formě obrazu.
Nyní jsou poznámky udržované v [jednom .docx souboru](https://campuscvut-my.sharepoint.com/personal/tesarj13_cvut_cz/_layouts/15/guestaccess.aspx?docid=0bfb2bdf298624cfd958ecec0995ad1e1&authkey=ARqZgO9VFIV1R9b1jJJu8Yc&e=4073622bdf1a474caf92164e278c5744) "hostovaném" na OneDrivu, což s sebou přináší značné výhody (snadná editace, automatické zvýraznění syntaxe, obrázky rovnou v souboru, minimální požadavky na nasazení), tak též nevýhody (webově špatně prezentovatelný a nesnadno dohledatelný formát, složité přispívání více lidí, linearita - chybějící struktura, špatná podpora jazykových mutací, nemožnost efektivně publikovat testy, jejich řešení a zdroje).
# Přispívání
Máte - li zájem získat body navíc stačí přispět předěláním nějaké kapitoly z mateřského souboru do markdownu.
## Co je to Markdown (.md)?
Markdown je jednoduchý značkovací jazyk využívající několik "značek" pro snadnější naformátování dokumentu. Zvládá vytvořit odkazy, zvýraznit syntaxi, přidat obrázky a mnohem víc. [Markdown tahák](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#links). 
## Kde začít
Pro inspiraci jak vytvořit článek odpovídající zdejším (velice čerstvým a kujným) pravidlům se podívejte na jakýkoliv soubor v dokumentaci. K uvedenému souboru se dostanete přes repositář na mém [githubu](https://github.com/tesar-tech/zodoc/tree/master/input/docs). Vybráním souboru a kliknutí na `Raw` zobrazíte textovou verzi souboru. 
## Jak tvořit
Existuje spoustu způsobů a editorů, které Markdown zvládají. Já mohu doporučit [Visual Studio Code](https://code.visualstudio.com/) (multiplatformní záležitost) a doplňky pro usnadnění práce s .md soubory. [Markdown All in One](https://marketplace.visualstudio.com/items?itemName=yzhang.markdown-all-in-one) a [Markdown Paste](https://marketplace.visualstudio.com/items?itemName=telesoho.vscode-markdown-paste-image) pro snadnější vkládání obrázků.
Obrázky je dobré vkládat vždy do složky `media` ve stejné složce jako je článek (opět zřete [repozitář](https://github.com/tesar-tech/zodoc/tree/master/input/docs)).
### Jak mají soubory vypadat
Nejde jenom o to, abyste překopírovali text z wordu do .md. Jde také o to, abyste kód spustili, opravili (třeba názvy proměnných), zadokumentovali (obrázky). Inspirujte se v již vytvořených souborech.

## Konvence

Pár tipů, jak tvořit dokumentaci. Pokud vám jsou některé následující pojmy tajné, nevěšte hlavy, stačí spolupracovat s již vytvořenými soubory, které tyto konvence respektují. 
- Soubory nazývejte výstižnými názvy
- Pro obrázky je nejlepší použít časovou značku (zmíněný doplněk pro vscode toto umí automaticky)
- Obrázky ukládejte do složky /media
- Obsahuje-li výstup více obrázků vytvořených pomocí funkce `subplot`, následný `imshow` dejte na stejný řádek.
- Uvádějte titulek i popis souboru (přes metadata)
- Podnadpisy jsou první úrovně (#). Hlavní nadpis je v metadatech jako `title` 
- Ukázky kódu patřičně zarovnejte (v Matlabu označit vše a potom Ctrl+I)

- V případě tvorby dokumentů do sekce `Exercises` jsou konvence lehce jiné. Vysvětlené jsou v ukázkovém cvičení. 

## Jak publikovat
Forkem repositáře a pull requestou. Je k tomu nutný účet na githubu a lehká znalost, jak to celé funguje. Návodů je všude fůra a samotný github vás směle navede. Tuto cestu vřele doporučuji (ve skutečnosti je to jeden z důvodů proč dokumentaci přesouvám tímto směrem) - jestli se chcete programování do budoucna věnovat, bude se vám tento základ hodit. Pro jednu novou část dokumentace (jeden .md soubor) vytvořte jednu pullrequestu. Já to okomentuji, vy opravíte, commitnete a pushnete do svého forlklého repozitáře. Až to bude v pořádku, pull requestu bude sloučena (merge) s mateřským adresářem.

## Co z toho? 
- Především dobrý pocit, že jste přispěli k zvyšování kvality výuky a naučili jste se něco nového. 
- 7 bodů do vašeho celoročního skóre za každý precizně vytvořený soubor (čím méně práce s tím budu mít já při editaci, tím více se přiblížíte těm 7 bodům)
- Připomínám, že během 14. výukového týdne bude zápočtové klání uzavřené. Stíhejte to včas.   
# Technologie - jak to funguje
- https://wyam.io pro generování statických stánek
- https://github.io pro hostování a sdílení
- https://appveyor.com pro buildění a nasazení
- https://github.com/MinhasKamal/DownGit pro stahování složek z githubu.







