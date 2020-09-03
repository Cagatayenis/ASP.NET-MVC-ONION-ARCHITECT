# ASP.NET-MVC-ONION-ARCHITECT
 E-Ticaret ASP.NET-MVC-ONION-ARCHITECT

Project Information<br/>
Language : `C#` <br/>
.Net Version :  `.Net Framework 4.6.1` <br/>
Architect: `ASP.NET MVC / Onion Architect`  <br/>
Database : `MSSQL` <br/>
ORM :  `Entityframework`<br/><br/>
**Merhabalar, proje yapılırken fonksiyonel süreçleri için YemekSepeti sitesi baz alınmıştır, çok katmanlı(n-tier) mimari olan "Onion Architect" kullanılmıştır.**
<br/><hr/>
## Onion Mimari İçeriği<br/>
Core Katmanında database crud operations interface ve genel yapılandırma ayarları oluşturulmuştur,<br/>
Model Katmanında proje kapsamında kullanılacak sınıflar ve onlara ait map'ler oluşturulmuş ve Core katmanı referans edilmiştir.<br/>
Service Katmanında Core ve Model katmanları referans edildikten sonra proje kapsamında veri tabanı ile crud operation işlemleri için Core katmanında set edilen interface, sınıflara kazandırılmıştır.<br/>
WebUI katmanında ücretsiz bir tema sayfalara düzenlenerek giydirilmiş ve kullanıcı-admin yönetimi birbirlerinden ayrılmıştır.<br/>
## Diger Bilgiler
Projede EntityFramework'un Codefirst Yaklasımı kullanılmıstır.Codefirst Convention kurallari devre dısı bırakılarak  manuel olarak tablolar olusturulmustur.<br/>
Kimlik Dogrulama ve Yetkilendirme işlemleri için Session Kullanılmıstır.
