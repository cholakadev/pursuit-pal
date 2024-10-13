import './noMatch.css';

function NoMatch() {
    return (
        <div className="no-match">
            <h1>404</h1>
            <h2>Page Not Found</h2>
            <p>The page you're looking for does not exist.</p>
            <a href="/">Go back to Home</a>
        </div>
    )
}

export default NoMatch;