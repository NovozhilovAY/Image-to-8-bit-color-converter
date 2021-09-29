# Описание
Приложение предназначено для создания изображений в стиле Pixel Art на основе обычных изображений различных форматов. 

Программа реализована на языке С#, с использованием среды разработки Visual Studio 2019 и применением технологии Windows Forms.
Для создания графического интерфейса был использован Guna UI Framework.    
# Руководство пользователя
### 1. Первым шагом нужно загрузить изображение с компьютера, нажав соответствующую кнопку меню  
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/pixelizer/open_image.png)
### 2. После загрузки изображения, нужно выбрать нужный уровень пикселизации при помощи ползунка, в правой части окна
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/pixelizer/pixelizing.gif)
### 3. Затем нужно выбрать цветовую палитру при помощи соответствующего пункта меню
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/pixelizer/palette_choose.png)
* 6 битная палитра содержит 64 цвета
* 8 битная палитра содержит 256 цветов
* 12 битная палитра содержит 4096 цветов
* 16 битная палитра содержит 65 536 цветов
### 4. Следующий шаг - нажатие на кнопку "Обработать"
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/pixelizer/process.png)
### 5. В новом окне откроется обработанное изображение, которое можно сохранить на устройство
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/pixelizer/save.png)
# Краткое описание основынх классов
### Pixelizer
Класс служит для пикселизации изображения. Аргументами основного метода process являются изображение и необходимый размер пикселя, метод возвращает изображение, с размером пикселей указанного размера.
### ImageToPaletteConverter
Класс переводит изображение в нужную цветовую палитру. Аргументами основного метода Convert являются изображение и палитра, метод возвращает изображение, в указанной палитре цветов. В процессе работы метода для каждого пикселя изображения выбирается наиболее похожий цвет из палитры.
### Palette
Базовый класс, описывающий цветовую палитру: возможные значения RGB каналов и метод их инициализации
### Palette6bit, Palette8bit, Palette12bit, Palette16bit
Производные классы от Palette. Описывают конкретнут цветовую палитру, а именно количество значений каждого цветового канала(R G B)
### FastBitmap
Для быстрого доступа к пикселям был использован класс [FastBitmap](https://github.com/LuizZak/FastBitmap)