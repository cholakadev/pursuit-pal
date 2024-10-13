import './App.css';
import { Routes, Route } from 'react-router-dom';
import Register from './modules/auth/components/register';
import ErrorBoundary from './modules/core/components/errorBoundary';
import NoMatch from './modules/core/components/noMatch/noMatch';

const Home = () => <h1>Home Page</h1>;

const App = () => {
  return (
     <>
          <ErrorBoundary>
            <Routes>
              <Route path="*" element={<NoMatch />} />
              <Route path="/" element={<Home />} />
              <Route path="/register" element={<Register />} />
            </Routes>
          </ErrorBoundary>
     </>
  );
};


export default App;
