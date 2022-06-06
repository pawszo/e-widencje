import {Link} from 'react-router-dom'
import { withStore } from "../../init/redux/RootReducer";

const Header = () => {
  return (
    <header className="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
    <div className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
              <span className="fs-4">e-widencje - Cyfrowe Ewidencje Krajowe</span>
    </div>

    <ul className="nav nav-pills">
    <li className="nav-item">
      <Link  className="nav-link" to='/dashboard'>Strona główna
      </Link>
    </li>
    <li className="nav-item">
      <Link  className="nav-link" to='/users'>Użytkownicy</Link>
    </li>
    <li className="nav-item">
      <Link  className="nav-link" to='/logout'>Wyloguj</Link>
    </li>
          
    
    </ul>
  </header>
  )
}

export {Header}
