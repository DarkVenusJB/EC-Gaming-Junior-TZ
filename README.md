# EC-Gaming-Junior-TZ ✨

## Переход на URP и архитектура

### URP

С переходом на URP особых проблем не возникло, но кастомный шедер не перевёлся. Попробовал поменять его через плагин Shader Forge, также пробовал переписать шейдер руками. Поэтому свечение просто отключено.

### Архитектура

При разрабоотке архитектуры создал базовый класс Tower, где реализовал весь базовый функционал башни,а особенности реализации каждой отдельной башни оставил в производных классах. Аналогичным образом поступил с проджектайлами и создал отдельный класс Projectile.

Для улучшения оптимизации применил паттерн "Пул объектов", его реализация находится  в классе ObjectPool. Этот класс является обобщённым, что позволило мне применить паттерн "Пул объектов" как для монстра, так и для проджектайлов. 

При работе старался руководствоваться принципами SOLID, а именно принципом единой ответственности, открытости/закрытости, а также принципом инверсии зависимостей.

## Стрельба на упреждение

Попробовал несколько разных способов расчёта упредждения, наиболее рабоччим оказался тот, который рассчитывает коэффициент корректировки на основании вектора скорости противника. Этот способ работает, но если у противника увеличивается скорость, то пушка начинает чаще промахиваться

## Плавный поворот пушки

Сделал плавный поворот пушки при помощи расчётак кватерниона и сферической линейной интерполяции