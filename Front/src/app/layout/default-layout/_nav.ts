import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  
  {
    name: 'Pages',
    url: '/login',
    iconComponent: { name: 'cil-star' },
    children: [
      {
        name: 'Login',
        url: '/login',
        icon: 'nav-icon-bullet',
      },
      {
        name: 'search',
        url: '/forms/search',
        icon: 'nav-icon-bullet',
      },
    ],
  },
 
 ];
