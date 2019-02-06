using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    

    [SerializeField]
    private PuzzleGameManager puzzleGameManager;

    [SerializeField]
    private LevelLocker levelLocker;

    //[SerializeField]
    //private StarsLocker starsLocker;

    [SerializeField]
    private LoadPuzzleGame loadPuzzleGame;

    [SerializeField]
    private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

    [SerializeField]
    private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    private string selectedPuzzle;

    private bool[] puzzle;

    public void BackToPuzzleSelectMenu()
    {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    public void SelectPuzzleLevel()
    {
        //starsLocker.DeactivateStars();
                    //since our levels are 0, 1, 2, ... etc, but names are stored at strings, we want the integer value of the level name which is a number
        int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        puzzle = levelLocker.GetPuzzleLevels(selectedPuzzle);

        if (puzzle[level])
        {
            puzzleGameManager.SetLevel(level);
            loadPuzzleGame.LoadPuzzle(level, selectedPuzzle);
        }

    }


    IEnumerator ShowPuzzleSelectMenu()
    {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideIn");
        puzzleLevelSelectAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        puzzleLevelSelectPanel.SetActive(false);
    }

    public void SetSelectedPuzzle(string selectedPuzzle)
    {
        this.selectedPuzzle = selectedPuzzle;
        Debug.Log("The Selected Puzzle is " + selectedPuzzle);
    }
}
