import './style.css'
import javascriptLogo from './javascript.svg'
import { environmentsComponent } from './src/concepts/01-environments'
import { callbackComponent } from './src/concepts/02-callbacks';
import { promesasComponent } from './src/concepts/03-promesas';
import { promiseRaceComponent } from './src/concepts/04-promise-race';
import { asyncComponent } from './src/concepts/05-async';
import { asyncAwaitComponent } from './src/concepts/06-async-await';
import { asyncAwaitOptComponent } from './src/concepts/07-async-await-optimizacion';
import { forAwaitComponent } from './src/concepts/08-for-await';

document.querySelector('#app').innerHTML = `
  <div>
    <a href="https://vitejs.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript" target="_blank">
      <img src="${javascriptLogo}" class="logo vanilla" alt="JavaScript logo" />
    </a>
    <h1>Hello Vite!</h1>
    <div class="card">
    
    </div>
  </div>
`
const element = document.querySelector('.card');
//environmentsComponent(element);
//callbackComponent(element);
//promesasComponent(element);
//promiseRaceComponent(element);
//asyncComponent(element);
//asyncAwaitComponent(element);
//asyncAwaitOptComponent(element);
forAwaitComponent(element);