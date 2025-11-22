<div dir="rtl" lang="he"><head>

<div class="box">
    <h2>תיאור פיתרון מטלה מתגלגלת 4 - תהליך ליבה</h2>
    <p>
        המשחק הוא גרסה דו־ממדית של "פרה עיוורת". השחקן שולט בפרה בחצר מגודרת,
        ובתוך החצר מסתובבים כמה בורחים שנעים באופן רנדומלי. המטרה: לתפוס את כולם
        לפני שהטיימר (60 שניות) נגמר.
    </p>
</div>

<div class="box">
    <h2>תהליך הליבה</h2>
    <ul>
        <li>השחקן מזיז את הפרה בעזרת החיצים.</li>
        <li>הבורחים זזים באקראיות ומשנים כיוון כשהם פוגעים בקירות.</li>
        <li>כשאזור ה־Trigger של הפרה נוגע בבורח – הבורח נעלם.</li>
        <li>אם כל הבורחים נתפסו עוברים למסך ניצחון.</li>
        <li>אם הזמן נגמר לפני כן עוברים למסך הפסד.</li>
    </ul>
</div>

<div class="box">
    <h2>איך מפעילים?</h2>
    <ul>
        <li>להריץ את הסצנה הראשית ב-Unity.</li>
        <li>לעקוב אחרי הטיימר בפינה העליונה.</li>
        <li>לדעת שהפרה לא יכולה לעבור דרך קירות ומכשולים כי הם מוגדרים בקוליידרים רגילים.</li>
    </ul>
</div>

<div class="box">
    <h2>ארכיטקטורת קוד</h2>
    <ul>
        <div dir="rtl" lang="he">
        <li><strong>Player/InputMover:</strong> אחראי על תנועת השחקן.</li>
        <li><strong>Player/CowCatcher:</strong> מזהה תפיסת בורחים.</li>
        <li><strong>Enemies/Runner:</strong> תנועה רנדומלית ושינוי כיוון בקירות.</li>
        <li><strong>Managers/GameManager:</strong> טיימר, ספירת בורחים, Winner/Loser.</li>
        <li><strong>Utils/Bourders:</strong> מגבלת תנועה בתוך החצר.</li>
        <li><strong>UI:</strong> טיימר והמסכים הסופיים.</li>
    </ul>
</div>
<div class="box" style="text-align:center;">
    <h2>תרשים UML</h2>

<pre style="display:inline-block; text-align:left;">
+-------------------+          +------------------+
|    GameManager    |          |      Runner      |
+-------------------+          +------------------+
| - totalRunners    |          | - speed          |
| - caughtRunners   |          | - moveDirection  |
| - roundTime       |          +------------------+
| - timerText       |          | +Update()        |
| - winnerScreen    |          | +OnCollision     |
| - loserScreen    |          +------------------+
+-------------------+
| +OnRunnerCaught() |
| +RestartLevel()   |
+---------+---------+
          ^
          |
+---------+---------+
|   CowCatcher      |
+-------------------+
| +OnTriggerEnter() |
+-------------------+
          ^
          |
+---------+----------------------------+
|                 Cow                  |
+--------------------------------------+
| Rigidbody2D + Collider2D רגיל        |
| Child: CatchZone עם Trigger           |
+--------------------------------------+
| +InputMover                           |
+--------------------------------------+

+-------------------+
|     Bourders      |
+-------------------+
| - minX, maxX      |
| - minY, maxY      |
+-------------------+
| +FixedUpdate()    |
+-------------------+
</pre>
</div>



<div class="box">
    <h2>סיכום</h2>
    <p>
        המשחק מציג בצורה ברורה את תהליך הליבה: תנועה, רדיפה, הימנעות ממכשול,
        תפיסת בורחים וניצחון/הפסד בהתאם לזמן. הגרפיקה בסיסית כי המטרה היא להדגים
        משחקיות ולא עיצוב.
    </p>
</div>

</body>
<a href="https://itamar-raz-dev-game.itch.io/blindcow-coreloop">ITCH</a>

