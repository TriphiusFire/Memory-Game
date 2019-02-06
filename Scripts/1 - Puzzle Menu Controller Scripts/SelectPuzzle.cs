using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour
{
    [SerializeField]
    private StarsLocker starsLocker;

    [SerializeField]
    private PuzzleGameManager puzzleGameManager;

    [SerializeField]
    private SelectLevel selectLevel;

    [SerializeField]
    private LevelLocker levelLocker;

    [SerializeField]
    private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

    [SerializeField]
    private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    private string selectedPuzzle;

    public void SelectedPuzzle()
    {
        starsLocker.DeactivateStars();

        //gets the current object we are touching in the scene
        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        puzzleGameManager.SetSelectedPuzzle(selectedPuzzle);

        levelLocker.CheckWhichLevelsAreUnlocked(selectedPuzzle);

        selectLevel.SetSelectedPuzzle(selectedPuzzle);

        StartCoroutine(ShowPuzzleLevelSelectMenu());
    }

    IEnumerator ShowPuzzleLevelSelectMenu()
    {
        puzzleLevelSelectPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideOut");
        puzzleLevelSelectAnim.Play("SlideIn");
        yield return new WaitForSeconds(1f);
        selectPuzzleMenuPanel.SetActive(false);
    }
    
}
