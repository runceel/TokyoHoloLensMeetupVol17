---
marp: true
theme: base
size: 16:9
pagenate: true
_pagenate: false
style: |
    h1, h2, h3, h4, h5, header, footer {
    }
    section {
        justify-content: start;
        background-color: white;
        font-family: 'Yu Gothic UI';
        color: black;
        font-size: 2.2em;
    }

    section.blue {
        justify-content: center;
        background-color: #0078D7;
        color: white;
    }
    section.blue > h1, 
    section.blue > h2, 
    section.blue > h3, 
    section.blue > h4, 
    section.blue > h5, 
    section.blue > header, 
    section.blue > footer{
        color: white;
    }
    section.blue > h1 {
        font-size: 2.5em;
    }

    section.simple {
        justify-content: center;
    }

    section.simple > h1 {
        font-size: 2.5em;
    }
    section.simple > p {
        font-size: 1.5em;
    }
---

<!-- _class: blue -->
# HoloLens 開発者向け!!
## Azureでサーバーサイドを簡単に開発しよう！

C#er
大田　一希

---

# 自己紹介
- 名前: Kazuki Ota (大田　一希)
- 仕事: 某会議系企業でエンジニアとして働いています
- 好き: C#, TypeScript, Azure, UWP, WPF, Xamarin, Vue.js
- 苦手: 型のない言語
### プライベート
ゲームを最近やりすぎてる。

![bg right:35%](images/profile6.jpg)

---

# 今日のゴール

### Azure でサーバーサイド開発をなるべく簡単にする方法を知ってもらう

---
<!-- _class: blue -->
# 個人的なお勧め Azure サービス

---

# Azure App Service

アプリを動かすためのサービス

- クラウドのカテゴリーとしては PaaS (Platform as a Service) / FaaS (Function as a Service)
- サーバーの管理はしない
- アプリを書いてデプロイしたら動く
- Web Apps (PaaS) / Function Apps (PaaS, FaaS)

---

# Cosmos DB

Azure で一番強い NoSQL DB

- 色々なタイプの API を提供する NoSQL DB
  - SQL API
  - Cassandra API
  - Mongo DB API
  - Gremlin API
  - Table API
  - etcd API

---

# SQL Database

リレーショナルデータベースが欲しかったらこれ

- SQL Server と、ほぼ同じ感じ

---

# Azure AD

認証機能使いたかったらこれ

- Azure AD
- Azure AD B2C (多分こっちのほうが皆にとって使いやすい)

---

# Azure SignalR Service

サーバーからクライアント方向に命令が送れる

- Web Apps / Function Apps と組み合わせて使う

---

# 今日ピックアップするもの

- Function Apps
- Cosmos DB
- SignalR Service
- Azure AD B2C

---

# 追加情報

- Azure 無料体験版 (22,500円 30 日)
  [Azure 無料アカウント](https://azure.microsoft.com/ja-jp/offers/ms-azr-0044p/)
- 無料で実際に Azure を使って学習できるサイト
  [Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/)

---
# ご清聴ありがとうございました！
<!-- 
_class: blue
-->
