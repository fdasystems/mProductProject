[33mcommit af6bbee33136f94b705319a4b73f14a7f6f11013[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m)[m
Author: Favio Andrada <desa2.it@assurant.com>
Date:   Mon Feb 24 22:20:45 2020 -0300

    markOneFinish

[1mdiff --git a/src/app/____app-routing.module.ts b/src/app/____app-routing.module.ts[m
[1mnew file mode 100644[m
[1mindex 0000000..b64b0ca[m
[1m--- /dev/null[m
[1m+++ b/src/app/____app-routing.module.ts[m
[36m@@ -0,0 +1,18 @@[m
[32m+[m[32mimport { NgModule } from '@angular/core';[m[41m [m
[32m+[m[32mimport {Routes, RouterModule} from '@angular/router';[m
[32m+[m[32mimport{ProductsComponent} from './components/products/products.component';[m
[32m+[m[32m// import {} from './components/about';[m
[32m+[m
[32m+[m
[32m+[m[32mconst routes: Routes = [[m
[32m+[m[32m{path: 'products', component: ProductsComponent },[m
[32m+[m[32m{ path: 'about', loadChildren: () => import('./components/pages/about/about.module').then(m => m.AboutModule) }[m
[32m+[m
[32m+[m[32m];[m
[32m+[m
[32m+[m[32m@NgModule({[m
[32m+[m[32m    imports: [RouterModule.forRoot(routes)],[m
[32m+[m[32m    exports: [RouterModule][m
[32m+[m[32m})[m
[32m+[m
[32m+[m[32mexport class AppRoutingModule {}[m
\ No newline at end of file[m
[1mdiff --git a/src/app/_orig.app.componen.html b/src/app/_orig.app.componen.html[m
[1mnew file mode 100644[m
[1mindex 0000000..3e87553[m
[1m--- /dev/null[m
[1m+++ b/src/app/_orig.app.componen.html[m
[36m@@ -0,0 +1,540 @@[m
[32m+[m[32m<!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * * * The content below * * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * * is only a placeholder * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * * and can be replaced. * * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * Delete the template below * * * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * to get started with your project! * * * * * * * * -->[m
[32m+[m[32m<!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * -->[m
[32m+[m
[32m+[m[32m<style>[m
[32m+[m[32m    :host {[m
[32m+[m[32m      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";[m
[32m+[m[32m      font-size: 14px;[m
[32m+[m[32m      color: #333;[m
[32m+[m[32m      box-sizing: border-box;[m
[32m+[m[32m      -webkit-font-smoothing: antialiased;[m
[32m+[m[32m      -moz-osx-font-smoothing: grayscale;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    h1,[m
[32m+[m[32m    h2,[m
[32m+[m[32m    h3,[m
[32m+[m[32m    h4,[m
[32m+[m[32m    h5,[m
[32m+[m[32m    h6 {[m
[32m+[m[32m      margin: 8px 0;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    p {[m
[32m+[m[32m      margin: 0;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .spacer {[m
[32m+[m[32m      flex: 1;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .toolbar {[m
[32m+[m[32m      position: absolute;[m
[32m+[m[32m      top: 0;[m
[32m+[m[32m      left: 0;[m
[32m+[m[32m      right: 0;[m
[32m+[m[32m      height: 60px;[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m      background-color: #1976d2;[m
[32m+[m[32m      color: white;[m
[32m+[m[32m      font-weight: 600;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .toolbar img {[m
[32m+[m[32m      margin: 0 16px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .toolbar #twitter-logo {[m
[32m+[m[32m      height: 40px;[m
[32m+[m[32m      margin: 0 16px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .toolbar #twitter-logo:hover {[m
[32m+[m[32m      opacity: 0.8;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .content {[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      margin: 82px auto 32px;[m
[32m+[m[32m      padding: 0 16px;[m
[32m+[m[32m      max-width: 960px;[m
[32m+[m[32m      flex-direction: column;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    svg.material-icons {[m
[32m+[m[32m      height: 24px;[m
[32m+[m[32m      width: auto;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    svg.material-icons:not(:last-child) {[m
[32m+[m[32m      margin-right: 8px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card svg.material-icons path {[m
[32m+[m[32m      fill: #888;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card-container {[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      flex-wrap: wrap;[m
[32m+[m[32m      justify-content: center;[m
[32m+[m[32m      margin-top: 16px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card {[m
[32m+[m[32m      border-radius: 4px;[m
[32m+[m[32m      border: 1px solid #eee;[m
[32m+[m[32m      background-color: #fafafa;[m
[32m+[m[32m      height: 40px;[m
[32m+[m[32m      width: 200px;[m
[32m+[m[32m      margin: 0 8px 16px;[m
[32m+[m[32m      padding: 16px;[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      flex-direction: row;[m
[32m+[m[32m      justify-content: center;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m      transition: all 0.2s ease-in-out;[m
[32m+[m[32m      line-height: 24px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card-container .card:not(:last-child) {[m
[32m+[m[32m      margin-right: 0;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card.card-small {[m
[32m+[m[32m      height: 16px;[m
[32m+[m[32m      width: 168px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card-container .card:not(.highlight-card) {[m
[32m+[m[32m      cursor: pointer;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card-container .card:not(.highlight-card):hover {[m
[32m+[m[32m      transform: translateY(-3px);[m
[32m+[m[32m      box-shadow: 0 4px 17px rgba(black, 0.35);[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card-container .card:not(.highlight-card):hover .material-icons path {[m
[32m+[m[32m      fill: rgb(105, 103, 103);[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card.highlight-card {[m
[32m+[m[32m      background-color: #1976d2;[m
[32m+[m[32m      color: white;[m
[32m+[m[32m      font-weight: 600;[m
[32m+[m[32m      border: none;[m
[32m+[m[32m      width: auto;[m
[32m+[m[32m      min-width: 30%;[m
[32m+[m[32m      position: relative;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .card.card.highlight-card span {[m
[32m+[m[32m      margin-left: 60px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    svg#rocket {[m
[32m+[m[32m      width: 80px;[m
[32m+[m[32m      position: absolute;[m
[32m+[m[32m      left: -10px;[m
[32m+[m[32m      top: -24px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    svg#rocket-smoke {[m
[32m+[m[32m      height: calc(100vh - 95px);[m
[32m+[m[32m      position: absolute;[m
[32m+[m[32m      top: 10px;[m
[32m+[m[32m      right: 180px;[m
[32m+[m[32m      z-index: -10;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    a,[m
[32m+[m[32m    a:visited,[m
[32m+[m[32m    a:hover {[m
[32m+[m[32m      color: #1976d2;[m
[32m+[m[32m      text-decoration: none;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    a:hover {[m
[32m+[m[32m      color: #125699;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .terminal {[m
[32m+[m[32m      position: relative;[m
[32m+[m[32m      width: 80%;[m
[32m+[m[32m      max-width: 600px;[m
[32m+[m[32m      border-radius: 6px;[m
[32m+[m[32m      padding-top: 45px;[m
[32m+[m[32m      margin-top: 8px;[m
[32m+[m[32m      overflow: hidden;[m
[32m+[m[32m      background-color: rgb(15, 15, 16);[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .terminal::before {[m
[32m+[m[32m      content: "\2022 \2022 \2022";[m
[32m+[m[32m      position: absolute;[m
[32m+[m[32m      top: 0;[m
[32m+[m[32m      left: 0;[m
[32m+[m[32m      height: 4px;[m
[32m+[m[32m      background: rgb(58, 58, 58);[m
[32m+[m[32m      color: #c2c3c4;[m
[32m+[m[32m      width: 100%;[m
[32m+[m[32m      font-size: 2rem;[m
[32m+[m[32m      line-height: 0;[m
[32m+[m[32m      padding: 14px 0;[m
[32m+[m[32m      text-indent: 4px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .terminal pre {[m
[32m+[m[32m      font-family: SFMono-Regular,Consolas,Liberation Mono,Menlo,monospace;[m
[32m+[m[32m      color: white;[m
[32m+[m[32m      padding: 0 1rem 1rem;[m
[32m+[m[32m      margin: 0;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .circle-link {[m
[32m+[m[32m      height: 40px;[m
[32m+[m[32m      width: 40px;[m
[32m+[m[32m      border-radius: 40px;[m
[32m+[m[32m      margin: 8px;[m
[32m+[m[32m      background-color: white;[m
[32m+[m[32m      border: 1px solid #eeeeee;[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      justify-content: center;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m      cursor: pointer;[m
[32m+[m[32m      box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);[m
[32m+[m[32m      transition: 1s ease-out;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .circle-link:hover {[m
[32m+[m[32m      transform: translateY(-0.25rem);[m
[32m+[m[32m      box-shadow: 0px 3px 15px rgba(0, 0, 0, 0.2);[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    footer {[m
[32m+[m[32m      margin-top: 8px;[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m      line-height: 20px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    footer a {[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .github-star-badge {[m
[32m+[m[32m      color: #24292e;[m
[32m+[m[32m      display: flex;[m
[32m+[m[32m      align-items: center;[m
[32m+[m[32m      font-size: 12px;[m
[32m+[m[32m      padding: 3px 10px;[m
[32m+[m[32m      border: 1px solid rgba(27,31,35,.2);[m
[32m+[m[32m      border-radius: 3px;[m
[32m+[m[32m      background-image: linear-gradient(-180deg,#fafbfc,#eff3f6 90%);[m
[32m+[m[32m      margin-left: 4px;[m
[32m+[m[32m      font-weight: 600;[m
[32m+[m[32m      font-family: -apple-system,BlinkMacSystemFont,Segoe UI,Helvetica,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji,Segoe UI Symbol;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .github-star-badge:hover {[m
[32m+[m[32m      background-image: linear-gradient(-180deg,#f0f3f6,#e6ebf1 90%);[m
[32m+[m[32m      border-color: rgba(27,31,35,.35);[m
[32m+[m[32m      background-position: -.5em;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    .github-star-badge .material-icons {[m
[32m+[m[32m      height: 16px;[m
[32m+[m[32m      width: 16px;[m
[32m+[m[32m      margin-right: 4px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    svg#clouds {[m
[32m+[m[32m      position: fixed;[m
[32m+[m[32m      bottom: -160px;[m
[32m+[m[32m      left: -230px;[m
[32m+[m[32m      z-index: -10;[m
[32m+[m[32m      width: 1920px;[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[41m  [m
[32m+[m[32m    /* Responsive Styles */[m
[32m+[m[32m    @media screen and (max-width: 767px) {[m
[32m+[m[41m  [m
[32m+[m[32m      .card-container > *:not(.circle-link) ,[m
[32m+[m[32m      .terminal {[m
[32m+[m[32m        width: 100%;[m
[32m+[m[32m      }[m
[32m+[m[41m  [m
[32m+[m[32m      .card:not(.highlight-card) {[m
[32m+[m[32m        height: 16px;[m
[32m+[m[32m        margin: 8px 0;[m
[32m+[m[32m      }[m
[32m+[m[41m  [m
[32m+[m[32m      .card.highlight-card span {[m
[32m+[m[32m        margin-left: 72px;[m
[32m+[m[32m      }[m
[32m+[m[41m  [m
[32m+[m[32m      svg#rocket-smoke {[m
[32m+[m[32m        right: 120px;[m
[32m+[m[32m        transform: rotate(-5deg);[m
[32m+[m[32m      }[m
[32m+[m[32m    }[m
[32m+[m[41m  [m
[32m+[m[32m    @media screen and (max-width: 575px) {[m
[32m+[m[32m      svg#rocket-smoke {[m
[32m+[m[32m        display: none;[m
[32m+[m[32m        visibility: hidden;[m
[32m+[m[32m      }[m
[32m+[m[32m    }[m
[32m+[m[32m  </style>[m
[32m+[m[41m  [m
[32m+[m[32m  <!-- Toolbar -->[m
[32m+[m[32m  <div class="toolbar" role="banner">[m
[32m+[m[32m    <img[m
[32m+[m[32m      width="40"[m
[32m+[m[32m      alt="Angular Logo"[m
[32m+[m[32m      src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyNTAgMjUwIj4KICAgIDxwYXRoIGZpbGw9IiNERDAwMzEiIGQ9Ik0xMjUgMzBMMzEuOSA2My4ybDE0LjIgMTIzLjFMMTI1IDIzMGw3OC45LTQzLjcgMTQuMi0xMjMuMXoiIC8+CiAgICA8cGF0aCBmaWxsPSIjQzMwMDJGIiBkPSJNMTI1IDMwdjIyLjItLjFWMjMwbDc4LjktNDMuNyAxNC4yLTEyMy4xTDEyNSAzMHoiIC8+CiAgICA8cGF0aCAgZmlsbD0iI0ZGRkZGRiIgZD0iTTEyNSA1Mi4xTDY2LjggMTgyLjZoMjEuN2wxMS43LTI5LjJoNDkuNGwxMS43IDI5LjJIMTgzTDEyNSA1Mi4xem0xNyA4My4zaC0zNGwxNy00MC45IDE3IDQwLjl6IiAvPgogIDwvc3ZnPg=="[m
[32m+[m[32m    />[m
[32m+[m[32m    <span>Welcome</span>[m
[32m+[m[32m      <div class="spacer"></div>[m
[32m+[m[32m      <a aria-label="Angular on twitter" target="_blank" rel="noopener" href="https://twitter.com/angular" title="Twitter">[m
[32m+[m[32m        <svg id="twitter-logo" height="24" data-name="Logo" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 400 400">[m
[32m+[m[32m          <rect width="400" height="400" fill="none"/>[m
[32m+[m[32m          <path d="M153.62,301.59c94.34,0,145.94-78.16,145.94-145.94,0-2.22,0-4.43-.15-6.63A104.36,104.36,0,0,0,325,122.47a102.38,102.38,0,0,1-29.46,8.07,51.47,51.47,0,0,0,22.55-28.37,102.79,102.79,0,0,1-32.57,12.45,51.34,51.34,0,0,0-87.41,46.78A145.62,145.62,0,0,1,92.4,107.81a51.33,51.33,0,0,0,15.88,68.47A50.91,50.91,0,0,1,85,169.86c0,.21,0,.43,0,.65a51.31,51.31,0,0,0,41.15,50.28,51.21,51.21,0,0,1-23.16.88,51.35,51.35,0,0,0,47.92,35.62,102.92,102.92,0,0,1-63.7,22A104.41,104.41,0,0,1,75,278.55a145.21,145.21,0,0,0,78.62,23" fill="#fff"/>[m
[32m+[m[32m        </svg>[m
[32m+[m[32m      </a>[m
[32m+[m[32m  </div>[m
[32m+[m[41m  [m
[32m+[m[32m  <button mat-flat-button color="primary" >click me FDA!</button>[m
[32m+[m[41m  [m
[32m+[m[32m  <div class="content" role="main">[m
[32m+[m[41m  [m
[32m+[m[32m  <mat-toolbar>testing Angular</mat-toolbar>[m
[32m+[m[41m  [m
[32m+[m[32m  <app-products></app-products>[m
[32m+[m[41m  [m
[32m+[m[41m  [m
[32m+[m[32m    <!-- Highlight Card -->[m
[32m+[m[32m    <div class="card highlight-card card-small">[m
[32m+[m[41m  [m
[32m+[m[32m      <svg id="rocket" alt="Rocket Ship" xmlns="http://www.w3.org/2000/svg" width="101.678" height="101.678" viewBox="0 0 101.678 101.678">[m
[32m+[m[32m        <g id="Group_83" data-name="Group 83" transform="translate(-141 -696)">[m
[32m+[m[32m          <circle id="Ellipse_8" data-name="Ellipse 8" cx="50.839" cy="50.839" r="50.839" transform="translate(141 696)" fill="#dd0031"/>[m
[32m+[m[32m          <g id="Group_47" data-name="Group 47" transform="translate(165.185 720.185)">[m
[32m+[m[32m            <path id="Path_33" data-name="Path 33" d="M3.4,42.615a3.084,3.084,0,0,0,3.553,3.553,21.419,21.419,0,0,0,12.215-6.107L9.511,30.4A21.419,21.419,0,0,0,3.4,42.615Z" transform="translate(0.371 3.363)" fill="#fff"/>[m
[32m+[m[32m            <path id="Path_34" data-name="Path 34" d="M53.3,3.221A3.09,3.09,0,0,0,50.081,0,48.227,48.227,0,0,0,18.322,13.437c-6-1.666-14.991-1.221-18.322,7.218A33.892,33.892,0,0,1,9.439,25.1l-.333.666a3.013,3.013,0,0,0,.555,3.553L23.985,43.641a2.9,2.9,0,0,0,3.553.555l.666-.333A33.892,33.892,0,0,1,32.647,53.3c8.55-3.664,8.884-12.326,7.218-18.322A48.227,48.227,0,0,0,53.3,3.221ZM34.424,9.772a6.439,6.439,0,1,1,9.106,9.106,6.368,6.368,0,0,1-9.106,0A6.467,6.467,0,0,1,34.424,9.772Z" transform="translate(0 0.005)" fill="#fff"/>[m
[32m+[m[32m          </g>[m
[32m+[m[32m        </g>[m
[32m+[m[32m      </svg>[m
[32m+[m[41m  [m
[32m+[m[32m      <span>{{ title }} app is running!</span>[m
[32m+[m[41m  [m
[32m+[m[32m      <svg id="rocket-smoke" alt="Rocket Ship Smoke" xmlns="http://www.w3.org/2000/svg" width="516.119" height="1083.632" viewBox="0 0 516.119 1083.632">[m
[32m+[m[32m        <path id="Path_40" data-name="Path 40" d="M644.6,141S143.02,215.537,147.049,870.207s342.774,201.755,342.774,201.755S404.659,847.213,388.815,762.2c-27.116-145.51-11.551-384.124,271.9-609.1C671.15,139.365,644.6,141,644.6,141Z" transform="translate(-147.025 -140.939)" fill="#f5f5f5"/>[m
[32m+[m[32m      </svg>[m
[32m+[m[41m  [m
[32m+[m[32m    </div>[m
[32m+[m[41m  [m
[32m+[m[32m    <!-- Resources -->[m
[32m+[m[32m    <h2>Resources</h2>[m
[32m+[m[32m    <p>Here are some links to help you get started:</p>[m
[32m+[m[41m  [m
[32m+[m[32m    <div class="card-container">[m
[32m+[m[32m      <a class="card" target="_blank" rel="noopener" href="https://angular.io/tutorial">[m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M5 13.18v4L12 21l7-3.82v-4L12 17l-7-3.82zM12 3L1 9l11 6 9-4.91V17h2V9L12 3z"/></svg>[m
[32m+[m[41m  [m
[32m+[m[32m        <span>Learn Angular</span>[m
[32m+[m[41m  [m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/></svg>    </a>[m
[32m+[m[41m  [m
[32m+[m[32m      <a class="card" target="_blank" rel="noopener" href="https://angular.io/cli">[m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M9.4 16.6L4.8 12l4.6-4.6L8 6l-6 6 6 6 1.4-1.4zm5.2 0l4.6-4.6-4.6-4.6L16 6l6 6-6 6-1.4-1.4z"/></svg>[m
[32m+[m[41m  [m
[32m+[m[32m        <span>CLI Documentation</span>[m
[32m+[m[41m  [m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/></svg>[m
[32m+[m[32m      </a>[m
[32m+[m[41m  [m
[32m+[m[32m      <a class="card" target="_blank" rel="noopener" href="https://blog.angular.io/">[m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M13.5.67s.74 2.65.74 4.8c0 2.06-1.35 3.73-3.41 3.73-2.07 0-3.63-1.67-3.63-3.73l.03-.36C5.21 7.51 4 10.62 4 14c0 4.42 3.58 8 8 8s8-3.58 8-8C20 8.61 17.41 3.8 13.5.67zM11.71 19c-1.78 0-3.22-1.4-3.22-3.14 0-1.62 1.05-2.76 2.81-3.12 1.77-.36 3.6-1.21 4.62-2.58.39 1.29.59 2.65.59 4.04 0 2.65-2.15 4.8-4.8 4.8z"/></svg>[m
[32m+[m[41m  [m
[32m+[m[32m        <span>Angular Blog</span>[m
[32m+[m[41m  [m
[32m+[m[32m        <svg class="material-icons" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/></svg>[m
[32m+[m[32m      </a>[m
[32m+[m[41m  [m
[32m+[m[32m    </div>[m
[32m+[m[41m  [m
[32m+[m[32m    <!-- Next Steps -->[m
[32m+[m[32m    <h2>Next Steps</h2>[m
[32m+[m[32m    <p>What do you want to do next with your app?</p>[m
[32m+[m[41m  [m
[32m+[m[32m    <input type="hidden" #selection>[m
[32m+[m[41m  [m
[32m+[m[32m    <div class="card-container">[m
[32m+[m[32m      <div class="card card-small" (click)="selection.value = 'component'" tabindex="0">[m
[32m+[m[32m          <svg class="material-icons" xmlns="http://www.w3.org/2000/